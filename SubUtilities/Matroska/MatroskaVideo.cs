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

    public BufferElementContent(long value) => _buffer = new MemoryStream(BitConverter.GetBytes(value));
    public BufferElementContent(ulong value) => _buffer = new MemoryStream(BitConverter.GetBytes(value));

    public BufferElementContent(byte[] buffer) => _buffer = new MemoryStream(buffer);
    
    public BufferElementContent(MemoryStream buffer) => _buffer = buffer;

    public long Size => _buffer.Length;

    public Stream ReadAsStream()
    {
        _buffer.Seek(0, SeekOrigin.Begin);
        return _buffer;
    }
}

public class StreamChunkElementContent : IElementContent
{
    private readonly Stream _stream;
    private readonly long _position;
    private readonly long _length;
    
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
            CreateSubtitleTrack(segment, "jp", "Custom Track");
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

            foreach (var child in children) child.SetParent(element);

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
        var tracksElement = segment.Children.First(
            x => x.Id == MatroskaElementRegistry.MatroskaTracks.Id    
        );

        // todo: automatically add tracks element
        if (tracksElement == default) throw new Exception("Expected tracks element!");
        
        // continue from last number
        var trackEntries = tracksElement.Children
            .Where(x => x.Id == MatroskaElementRegistry.MatroskaTrackEntry.Id)
            .ToArray();
        
        var highestTrackNumber = trackEntries
            .Select(x => x.Children.SingleOrDefault(y => y.Id == MatroskaElementRegistry.MatroskaTrackNumber.Id))
            .Max(x => x?.ReadUIntContent() ?? 0);

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
        
        // trackElement.SetParent(tracksElement);

        return trackElement;
    }
    
    public Element CreateSubtitleBlock(
        SrtSegment segment, 
        int track
    )
    {
        // step 1: determine content 
        // https://matroska.sourceforge.net/technical/specs/index.html#TimecodeScale
        // todo: account for different timescales (see segment info -> timestamp scale)

        var duration = (long)(segment.TimeRange.To - segment.TimeRange.From).TotalMilliseconds;
        // var durationWidth = VInt.FromData(BitMask.SizeOf(duration));

        var blockDurationElement = ElementFactory.CreateElement(
            MatroskaElementRegistry.MatroskaBlockDuration,
            new BufferElementContent(duration)
        );

        var trackNumber = VInt.FromData(track);
        var relativeTimestamp = VInt.FromData(0);
        var flags = VInt.FromData(0);
        var text = Encoding.UTF8.GetBytes(segment.Text);

        // https://matroska.sourceforge.net/technical/specs/index.html#block_structure
        var contentStream = new MemoryStream();
        contentStream.Write(trackNumber.AsBytes());
        contentStream.Write(relativeTimestamp.AsBytes());
        contentStream.Write(flags.AsBytes());
        contentStream.Write(text);

        var blockElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaBlock, contentStream);

        var blockGroupElement = ElementFactory.CreateElement(MatroskaElementRegistry.MatroskaBlockGroup, new[]
        {
            blockElement,
            blockDurationElement
        });
        
        return blockGroupElement;
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

