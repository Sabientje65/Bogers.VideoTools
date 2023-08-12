using System.Text;
using SubUtilities.Generated;

namespace SubUtilities.Matroska;

// https://www.matroska.org/technical/subtitles.html
// https://matroska-org.github.io/libebml/specs.html
// https://www.rfc-editor.org/rfc/rfc8794.html
// For inspection, we can use a combination of https://mh-nexus.de/en/downloads.php?product=HxD20 and https://mkvtoolnix.download/downloads.html#windows
// https://www.rfc-editor.org/rfc/rfc8794.pdf

// EBML -> Define different datatypes, separate reader library?

// For reading/writing element (content)
// introduce datasource concept, a datasource will serve as a single source to read/write data from a predefined byte-range
// this byte-range can be either memory based or file (stream) based
// datasources will serve as a single interface for communicating between existing/new elements
// by means of assigning a static byterange to at least 'stream'/'file' based datasources, we also remove the need
// for having to keep track of new element positions when shuffling elements around (adding new elements etc)

public interface IElementContent // IElementContent?
{
    long Size { get; }
    
    Stream ReadAsStream();
}

public static class ElementContentExtensions
{
    public static byte[] ReadAsBytes(this IElementContent content)
    {
        var bytes = new byte[content.Size];
        _ = content.ReadAsStream().Read(bytes);
        return bytes;
    }
}

public class NoElementContent : IElementContent
{
    public static readonly NoElementContent Instance = new NoElementContent();

    public long Size => 0;
    public Stream ReadAsStream() => Stream.Null;
}

public class BufferElementContent : IElementContent
{
    private readonly MemoryStream _buffer;

    public BufferElementContent(long value) : this(ToBuffer(value)) {}

    public BufferElementContent(ulong value) : this(ToBuffer((long)value)) {}

    public BufferElementContent(byte[] buffer) => _buffer = new MemoryStream(buffer);
    
    public BufferElementContent(MemoryStream buffer) => _buffer = buffer;

    public long Size => _buffer.Length;

    public Stream ReadAsStream()
    {
        _buffer.Seek(0, SeekOrigin.Begin);
        return _buffer;
    }

    private static byte[] ToBuffer(long value)
    {
        var vint = VInt.FromData(value);
        var bytes = new byte[vint.Width];
        
        for (var octet = vint.Width; octet > 0; octet--) bytes[vint.Width - octet] = BitMask.ReadOctet(value, octet - 1);

        return bytes;
    }
}

public class StreamChunkElementContent : IElementContent
{
    private readonly Stream _stream;
    private readonly long _position;
    private readonly long _length;

    public long Position => _position;
    
    public StreamChunkElementContent(Stream stream, long position, long length)
    {
        _stream = stream;
        _position = position;
        _length = length;
    }

    public long Size => _length;
    public Stream ReadAsStream() => new StreamChunk(_stream, _position, _length);

    private class StreamChunk : Stream
    {
        private readonly Stream _stream;
        private readonly long _length;
        private readonly long _startPosition;
        private long _position;
        
        public StreamChunk(
            Stream stream,
            long position,
            long length
        )
        {
            _stream = stream;
            _length = length;
            _startPosition = position;
        }
        
        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            PrepareStreamForRead();
            
            // prevent reading outside of assigned buffer 
            var advanced = offset + count;
            if (_position + advanced > _length)
            {
                count = (int)(_length - (_position + offset));
            }

            _position += count;
            
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin != SeekOrigin.Begin) throw new NotImplementedException();
            
            _position = offset;
            
            return _stream.Seek(
                _startPosition + offset,
                origin
            );
        }

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override bool CanRead => true;
        public override bool CanSeek => _stream.CanSeek;
        public override bool CanWrite => false;
        public override long Length => _length;

        public override long Position
        {
            get => _position;
            set => Seek(value, SeekOrigin.Begin);
        }

        private void PrepareStreamForRead()
        {
            // ensure our wrapped stream actually matches our internal position marker
            var expectedPosition = _startPosition + _position;
            if (_stream.Position == expectedPosition) return;

            Seek(_position, SeekOrigin.Begin);
        }
    }
}

public class EBMLHeader
{
    public int EBMLVersion { get; set; }

    public int EBMLReadVersion { get; set; }

    public int EBMLSizeLength { get; set; }

    public string DocumentType { get; set; }

    public int DocumentTypeVersion { get; set; }

    public int DocumentTypeReadVersion { get; set; }
}

public class MatroskaVideo
{
    private static Stream _stream;

    // should generate this from spec
    

    public static void Test()
    {
        // Parse Matroska file
        try
        {
            // var file = @"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\test5.mkv";
            var file = @"D:\Users\danny\Downloads\matroska_test_w1_1\test5.mkv"; // start off simple
            var srt = ReadSrt();
            
            _stream = new BufferedStream(File.OpenRead(file));
            var reader = new EBMLElementReader(_stream);

            // step 1: reading the header
            // an ebml document always starts with a header containing the following 4 bytes: 0x1A45DFA3
            var masterElement = reader.ReadRootElement();
            foreach (var element in masterElement.Children)
            {
                object elementContent = element.Type switch
                {
                    ElementType.SignedInteger => element.ReadIntContent(),
                    ElementType.UnsignedInteger => element.ReadUIntContent(),
                    
                    ElementType.ASCIIString => element.ReadStringContent(),
                    ElementType.Utf8String => element.ReadStringContent(),
                    // ElementType.Float => expr,
                    // ElementType.Date => expr,
                    // ElementType.Master => expr,
                    // ElementType.Binary => expr,
                    // ElementType.Unknown => expr,
                    _ => String.Empty
                }; 
                
                Console.WriteLine($"{WellKnownEBMLIds.Lookup[element.Id]}: {elementContent}");
            }
            
            // ConsumeMasterElement(masterElement);
            
            if(masterElement.Id != WellKnownEBMLIds.EBML) throw new MalformedDocumentException("Expected master elementId to be: 0x1A45DFA3");
            
            // step 2: read our segment
            var segment = reader.ReadRootElement();
            var segmentWrapper = segment;
            
            var trackElement = CreateSubtitleTrack(segmentWrapper, "nld", "Custom Track");
            var trackPosition = trackElement.FindSingle(MatroskaElementRegistry.MatroskaTrackNumber)!.ReadUIntContent();
            
            // foreach (var subSegment in srt.Segments)
            // {
            //     CreateSubtitleBlock(segmentWrapper, subSegment, trackPosition);
            // }
            
            // ConsumeMasterElement(segment);

            WriteDocument(new[] { masterElement, segment });

            // step 3: determine the blocks over which our subs should span

            // importanté, when writing our subs, we should also be bumping our seekhead elements

            // step 4: write our output

        }
        finally
        {
            _stream.Dispose();
        }
    }

    // public class SizeChangedArgs : EventArgs
    // {
    //     public long SizeChange { get; }
    //     
    //     public SizeChangedArgs(long sizeChange)
    //     {
    //         SizeChange = sizeChange;
    //     }
    // }

    // public delegate void SizeChangedEventHandler(object sender, SizeChangedArgs args);
    
    // public class MatroskaElementWrapper
    // {
    //     private readonly Element _ebmlElement;
    //
    //     public Element EBMLElement => _ebmlElement;
    //
    //     private readonly List<MatroskaElementWrapper> _children = new List<MatroskaElementWrapper>();
    //
    //     private MatroskaElementWrapper? _parent;
    //
    //     public MatroskaElementWrapper(Element ebmlElement)
    //     {
    //         _ebmlElement = ebmlElement;
    //     }
    //
    //     public EventHandler<SizeChangedArgs> OnSizeChanged;
    //
    //     public MatroskaElementWrapper Add(Element ebmlElement)
    //     {
    //         var wrapper = new MatroskaElementWrapper(ebmlElement);
    //         Add(wrapper);
    //         return wrapper;
    //     }
    //
    //     private void Add(MatroskaElementWrapper wrapper, bool isNew)
    //     {
    //         wrapper._ebmlElement.SetParent(_ebmlElement);
    //         _children.Add(wrapper);
    //         wrapper._parent = this;
    //         
    //         wrapper.OnSizeChanged += (sender, args) =>
    //         {
    //             _ebmlElement.Size += VInt.FromData(args.SizeChange);
    //             
    //             // also reposition siblings
    //             FindNextSibling()?.Reposition(args.SizeChange);
    //             OnSizeChanged?.Invoke(sender, args);
    //
    //             if (_ebmlElement.Id != MatroskaElementRegistry.MatroskaSegment.Id) return;
    //
    //             // if any of our seekheads changes size, we should trigger a re-index at the end
    //             // var shouldReindex = false;
    //             
    //             // for segments, we also want to update our seekhead positions
    //             foreach (var seekPosition in FindMultiple(MatroskaElementRegistry.MatroskaSeekPosition.Id))
    //             {
    //                 var currentPosition = seekPosition._ebmlElement.ReadUIntContent();
    //                 var newPosition = currentPosition + (ulong)args.SizeChange;
    //                 var newContent = new BufferElementContent(newPosition);
    //                 // shouldReindex = shouldReindex || seekPosition._ebmlElement.Content.Size != newContent.Size;
    //                 seekPosition._ebmlElement.Content = newContent;
    //                 
    //             }
    //         };
    //
    //         if (isNew)
    //         {
    //             var previous = wrapper.FindPreviousSibling();
    //             if (previous != null)
    //             {
    //                 wrapper.Reposition(
    //                     previous.EBMLElement.NextSibling
    //                 );                    
    //             }
    //
    //             
    //             wrapper.OnSizeChanged?.Invoke(this, new SizeChangedArgs(wrapper._ebmlElement.HeaderSize + wrapper._ebmlElement.Size.Data));    
    //         }
    //     }
    //
    //     public void Add(MatroskaElementWrapper wrapper) => Add(wrapper, true);
    //     
    //     public void Reposition(long relativeOffset)
    //     {
    //         _ebmlElement.Position += relativeOffset;
    //         foreach (var child in _children) child.Reposition(relativeOffset);
    //         FindNextSibling()?.Reposition(relativeOffset);
    //     }
    //     
    //     private MatroskaElementWrapper? FindPreviousSibling()
    //     {
    //         if (_parent == null) return null;
    //         var selfIdx = _parent._children.IndexOf(this);
    //         if (selfIdx - 1 < 0) return null;
    //         
    //         return _parent._children.Skip(selfIdx - 1).FirstOrDefault();
    //     } 
    //
    //     private MatroskaElementWrapper? FindNextSibling()
    //     {
    //         if (_parent == null) return null;
    //         var selfIdx = _parent._children.IndexOf(this);
    //         return _parent._children.Skip(selfIdx + 1).FirstOrDefault();
    //     }
    //
    //     public MatroskaElementWrapper? FindSingle(long? id) => FindMultiple(id).SingleOrDefault();
    //     
    //     public IEnumerable<MatroskaElementWrapper> FindMultiple(long? id)
    //     {
    //         // depth first traversal
    //         var remaining = new Stack<MatroskaElementWrapper>(_children);
    //
    //         while (remaining.Any())
    //         {
    //             var current = remaining.Pop();
    //             if (current._ebmlElement.Id == new ElementId(id.Value)) yield return current;
    //             foreach (var child in current._children) remaining.Push(child);
    //         }
    //     }
    //
    //     public static MatroskaElementWrapper CreateForTree(Element root)
    //     {
    //         var wrapper = new MatroskaElementWrapper(root);
    //
    //         foreach (var child in root.Children.ToArray())
    //         {
    //             wrapper.Add(CreateForTree(child), false);
    //         }
    //         
    //         return wrapper;
    //     }
    // }
    
    // public class MatroskaSegment
    // {
    //     private MatroskaSeekHead _seekHead;
    //
    //     private List<MatroskaTrack> _tracks = new List<MatroskaTrack>();
    //
    //     public long Size { get; set; }
    //
    //     public void AddTrack(MatroskaTrack track)
    //     {
    //     }
    // }

    // public class MatroskaSeekHead
    // {
    //     public IEnumerable<MatroskaSeekEntry> Entries { get; }
    // }

    // public class MatroskaSeekEntry
    // {
    //     
    //     
    //     public long GetSeekPosition()
    //     {
    //         
    //     }
    //     
    //     public void SetSeekPosition()
    //     {
    //         
    //     }
    // }
    //
    // public class MatroskaTrack
    // {
    // }

    public class ElementFactory
    {

        public static Element CreateElement(
            IMatroskaElement definition,
            IElementContent content
        )
        {
            return new Element(
                new ElementId(definition.Id!.Value),
                VInt.FromData(content.Size),
                definition.Type,
                0,
                content,
                null
            );
        }

        public static Element CreateElement( IMatroskaElement definition, MemoryStream content ) => CreateElement(definition, new BufferElementContent(content));
        public static Element CreateElement( IMatroskaElement definition, byte[] content ) => CreateElement(definition, new BufferElementContent(content));
        public static Element CreateElement( IMatroskaElement definition, ulong content ) => CreateElement(definition, new BufferElementContent(content));

        public static Element CreateElement( IMatroskaElement definition, Element[] children )
        {
            var size = children.Sum(BitMask.SizeOf);

            var element = new Element(
                new ElementId(definition.Id!.Value),
                VInt.FromData(size),
                definition.Type,
                0,
                new NoElementContent()
            );

            // long nextPos = element.HeaderSize + 1;

            foreach (var child in children)
            {
                // child.Position = nextPos;
                // nextPos += BitMask.SizeOf(child);
                element.Add(child);
                // child.SetParent();
            }

            return element;
        }
    }

    public class SubTitleTrack
    {
        public Element Element { get; }

        public SubTitleTrack(Element element)
        {
            Element = element;
        }

        public ulong TrackNumber => FindChild(MatroskaElementRegistry.MatroskaTrackNumber).ReadUIntContent();

        private Element FindChild(IMatroskaElement definition) => Element.Children
            .Single(x => x.Id == MatroskaElementRegistry.MatroskaTrackNumber.Id);
    }
    
    private static Element CreateSubtitleTrack(Element segment, string language, string name)
    {
        var tracksElement = segment.FindSingle(MatroskaElementRegistry.MatroskaTracks);

        // todo: automatically add tracks element
        if (tracksElement == default) throw new Exception("Expected tracks element!");
        
        // continue from last number
        var highestTrackNumber = tracksElement.FindMultiple(MatroskaElementRegistry.MatroskaTrackNumber)
            .Max(x => x.ReadUIntContent());
        
        // var highestTrackNumber = trackEntries
        //     .Select(x => x.Children.SingleOrDefault(y => y.Id == MatroskaElementRegistry.MatroskaTrackNumber.Id))
        //     .Max(x => x?.ReadUIntContent() ?? 0);

        var trackNumber = highestTrackNumber + 1;
        var trackId = new byte[4];
        Random.Shared.NextBytes(trackId);

        var trackNumberElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackNumber, trackNumber);
        var trackIdElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackUID, trackId);
        var trackTypeElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackType, 0x11); // subtitle
        var defaultTrackElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaFlagDefault, 0);
        var lacingElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaFlagLacing, 0);
        var codecElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaCodecID, Encoding.ASCII.GetBytes("S_TEXT/UTF8"));
        var languageElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaLanguage, Encoding.ASCII.GetBytes(language));
        var nameElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaName, Encoding.UTF8.GetBytes(name));

        var trackElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackEntry, new[]
        {
            trackNumberElement,
            trackIdElement,
            trackTypeElement,
            defaultTrackElement,
            lacingElement,
            codecElement,
            languageElement,
            nameElement
        });

        tracksElement.Add(trackElement);

        return trackElement;

        // trackElement.SetParent(tracksElement);
        // tracksElement.Size += trackElement.Size;

        // return new SubTitleTrack(trackElement);
    }

    // private static SubTitleTrack CreateSubtitleTrack(Element segment, string language, string name)
    // {
    //     var tracksElement = segment.Children.First(
    //         x => x.Id == MatroskaElementRegistry.MatroskaTracks.Id    
    //     );
    //
    //     // todo: automatically add tracks element
    //     if (tracksElement == default) throw new Exception("Expected tracks element!");
    //     
    //     // continue from last number
    //     var trackEntries = tracksElement.Children
    //         .Where(x => x.Id == MatroskaElementRegistry.MatroskaTrackEntry.Id)
    //         .ToArray();
    //     
    //     var highestTrackNumber = trackEntries
    //         .Select(x => x.Children.SingleOrDefault(y => y.Id == MatroskaElementRegistry.MatroskaTrackNumber.Id))
    //         .Max(x => x?.ReadUIntContent() ?? 0);
    //
    //     var trackNumber = highestTrackNumber + 1;
    //     var trackId = new byte[4];
    //     Random.Shared.NextBytes(trackId);
    //
    //     var trackNumberElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackNumber, trackNumber);
    //     var trackIdElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackUID, trackId);
    //     var trackTypeElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackType, 0x11); // subtitle
    //     var defaultTrackElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaFlagDefault, 0);
    //     var lacingElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaFlagLacing, 0);
    //     var codecElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaCodecID, Encoding.ASCII.GetBytes("S_TEXT/UTF8"));
    //     var languageElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaLanguage, Encoding.ASCII.GetBytes(language));
    //     var nameElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaName, Encoding.UTF8.GetBytes(name));
    //
    //     var trackElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaTrackEntry, new[]
    //     {
    //         trackNumberElement,
    //         trackIdElement,
    //         trackTypeElement,
    //         defaultTrackElement,
    //         lacingElement,
    //         codecElement,
    //         languageElement,
    //         nameElement
    //     });
    //     
    //     tracksElement.Add(trackElement);
    //     // trackElement.SetParent();
    //     // tracksElement.Size += trackElement.Size;
    //
    //     return new SubTitleTrack(trackElement);
    // }
    
    private static void CreateSubtitleBlock(
        Element segment,
        SrtSegment srtSegment, 
        ulong track
    )
    {
        // step 1: determine content 
        // https://matroska.sourceforge.net/technical/specs/index.html#TimecodeScale
        // todo: account for different timescales (see segment info -> timestamp scale)

        var clustersWithTimestamps = segment.FindMultiple(MatroskaElementRegistry.MatroskaCluster)
            .Select(x =>
            {
                var ts = x.FindSingle(MatroskaElementRegistry.MatroskaTimestamp)?.ReadUIntContent();
                
                return new
                {
                    Cluster = x,
                    Timestamp = ts.HasValue ? TimeSpan.FromMilliseconds(ts.Value) : (TimeSpan?)null
                };
            })
            .Where(x => x.Timestamp.HasValue)
            .ToArray();

        var cluster = clustersWithTimestamps
            .Where(x => x.Timestamp < srtSegment.TimeRange.From)
            .OrderBy(x => x.Timestamp.Value)
            .LastOrDefault();

        if (cluster == null) return;
        var clusterIdx = segment.FindMultiple(MatroskaElementRegistry.MatroskaCluster).ToList()
            .IndexOf(cluster.Cluster);

        var duration = (long)(srtSegment.TimeRange.To - srtSegment.TimeRange.From).TotalMilliseconds;

        // var durationWidth = VInt.FromData(BitMask.SizeOf(duration));

        var blockDurationElement = ElementFactory.CreateElement(
            MatroskaElementRegistry.MatroskaBlockDuration,
            new BufferElementContent(duration)
        );

        var trackNumber = VInt.FromData((long)track);
        var relativeTimestamp = VInt.FromData(0);
        var flags = VInt.FromData(0);

        // https://matroska.sourceforge.net/technical/specs/index.html#block_structure
        var contentStream = new MemoryStream();
        contentStream.Write(trackNumber.AsBytes());
        contentStream.Write(relativeTimestamp.AsBytes());
        contentStream.Write(flags.AsBytes());
        contentStream.Write(Encoding.ASCII.GetBytes("Teeeeest"));

        var blockElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaBlock, contentStream);

        var blockGroupElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaBlockGroup, new[]
        {
            blockElement,
            blockDurationElement
        });

        cluster.Cluster.Add(blockGroupElement);
    }
    
    private static SrtFile ReadSrt()
    {
        var srtFile = @"D:\Users\danny\Videos\Subs\Planetes JP 1-26 [Netflix]\Planetes JP 1-26 [Netflix]\Planetes.S01E19.CC.ja.srt";
        using var stream = File.OpenRead(srtFile);
        return SrtFile.Parse(stream).GetAwaiter().GetResult();
    }
    
    private static void WriteDocument(IEnumerable<Element> elements)
    {
        using var target = File.Create(@"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\test5-copy.mkv");
        
        // reset source to start
        // ResetStream();

        var leftover = new List<Element>(elements);

        while (leftover.Count != 0)
        {
            var element = leftover[0];
            leftover.RemoveAt(0);
            
            // process elements in order, parent -> child -> sibling
            foreach (var child in element.Children.Reverse()) leftover.Insert(0, child);

            if (element.Id == MatroskaElementRegistry.MatroskaTrackEntry.Id)
            {
                var trackNumber = new SubTitleTrack(element).TrackNumber;
                Console.WriteLine(trackNumber);
            }
            
            target.Write(element.Id.AsVInt().AsBytes());
            target.Write(element.Size.AsBytes());
            var contentReader = element.Type == ElementType.Master ? NoElementContent.Instance : element.Content;
            contentReader.ReadAsStream().CopyTo(target);
        }
    }
}

// TODO: Investigate 'Length' type as a bridge between different numeric types?

// structures representing the lowest individual aspects of our ebml documents

public interface IElement<TSelf, TValue> where TSelf : IElement<TSelf, TValue>
{

    ElementId Id { get; }
        
}

