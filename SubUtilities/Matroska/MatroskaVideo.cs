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

public interface IContentReader
{
    Stream ReadAsStream();
}

// public static class ContentReaderExtensions
// {
//     public static VInt ReadVInt(this IContentReader contentReader)
//     {
//         
//     }
//
//     public static byte[] ReadBytes(this IContentReader contentReader)
//     {
//         
//     }
// }

public class NoContentReader : IContentReader
{
    public static readonly NoContentReader Instance = new NoContentReader();
    
    public Stream ReadAsStream() => Stream.Null;
}

public class BufferContentReader : IContentReader
{
    private readonly MemoryStream _buffer;

    public BufferContentReader(long value) => _buffer = new MemoryStream(BitConverter.GetBytes(value));
    
    public BufferContentReader(byte[] buffer) => _buffer = new MemoryStream(buffer);
    
    public BufferContentReader(MemoryStream buffer) => _buffer = buffer;
    
    public Stream ReadAsStream() => _buffer;
}

public class StreamChunkContentReader : IContentReader
{
    private readonly Stream _stream;
    private readonly long _position;
    private readonly long _length;
    
    public StreamChunkContentReader(Stream stream, long position, long length)
    {
        _stream = stream;
        _position = position;
        _length = length;
    }

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
    private static class WellKnownIds
    {
        /// <summary>
        /// Master element
        /// \EBML
        /// </summary>
        public const int EBML = 0x1A45DFA3;

        /// <summary>
        /// Version element, uint
        /// \EBML\EBMLVersion
        ///
        /// Document version
        /// </summary>
        public const int Version = 0x4286;

        /// <summary>
        /// ReadVersion element, uint
        /// \EBML\EBMLReadVersion
        ///
        /// Minimum version for reading
        /// </summary>
        public const int ReadVersion = 0x42F7;

        /// <summary>
        /// MaxIdLength, uint
        /// \EBML\EBMLMaxIDLength
        /// 
        /// Maximum element id length, defaults to 4
        /// </summary>
        public const int MaxIdLength = 0x42F2;
        
        /// <summary>
        /// MaxSizeLength, uint
        /// \EBML\EBMLMaxSizeLength
        /// 
        /// Maximum element size, defaults to 8
        /// </summary>
        public const int MaxSizeLength = 0x42F3;
        
        /// <summary>
        /// Doctype, string
        /// \EBML\DocType
        ///
        /// A string that describes and identifies the content of the EBML Body that follows this EBML Header.
        /// </summary>
        public const int DocType = 0x4282;
        
        /// <summary>
        /// DocTypeVersion, uint
        /// \EBML\DocTypeVersion
        ///
        /// Defaults to 1
        /// The version of DocType interpreter used to create the EBML Document.
        /// </summary>
        public const int DocTypeVersion = 0x4287;
        
        /// <summary>
        /// DocTypeReadVersion, uint
        /// \EBML\DocTypeReadVersion
        ///
        /// Defaults to 1
        /// The minimum DocType version an EBML Reader has to support to read this EBML Document. The value of the DocTypeReadVersion Element MUST be less than or equal to the value of the DocTypeVersion Element.
        /// </summary>
        public const int DocTypeReadVersion = 0x4285;
        
        /// <summary>
        /// DocTypeExtension, master
        /// \EBML\DocTypeExtension
        ///
        /// A DocTypeExtension adds extra Elements to the main DocType+DocTypeVersion tuple it's attached to. An EBML Reader MAY know these extra Elements and how to use them. A DocTypeExtension MAY be used to iterate between experimental Elements before they are integrated into a regular DocTypeVersion. Reading one DocTypeExtension version of a DocType+DocTypeVersion tuple doesn't imply one should be able to read upper versions of this DocTypeExtension.
        /// </summary>
        public const int DocTypeExtension = 0x4281;
        
        /// <summary>
        /// DocTypeExtensionName, String
        /// \EBML\DocTypeExtension\DocTypeExtensionName
        ///
        /// The name of the DocTypeExtension to differentiate it from other DocTypeExtensions of the same DocType+DocTypeVersion tuple. A DocTypeExtensionName value MUST be unique within the EBML Header.
        /// </summary>
        public const int DocTypeExtensionName = 0x4283;
        
        /// <summary>
        /// DocTypeExtensionVersion, uint
        /// \EBML\DocTypeExtension\DocTypeExtensionVersion
        ///
        /// The version of the DocTypeExtension. Different DocTypeExtensionVersion values of the same DocType + DocTypeVersion + DocTypeExtensionName tuple MAY contain completely different sets of extra Elements. An EBML Reader MAY support multiple versions of the same tuple, only one version of the tuple, or not support the tuple at all.
        /// </summary>
        public const int DocTypeExtensionVersion = 0x4284;

        /// <summary>
        /// Cyclic Redundancy Check
        /// </summary>
        public const int CRC32 = 0xBF;
        
        /// <summary>
        /// Void, binary
        ///
        /// Element no data, used for marking wiped sectors, reserved space, etc.
        /// </summary>
        public const int Void = 0xEC;

        public static IDictionary<int, string> Lookup = new Dictionary<int, string>
        {
            { EBML, nameof(EBML) },
            { Version, nameof(Version) },
            { ReadVersion, nameof(ReadVersion) },
            { MaxIdLength, nameof(MaxIdLength) },
            { MaxSizeLength, nameof(MaxSizeLength) },
            { DocType, nameof(DocType) },
            { DocTypeVersion, nameof(DocTypeVersion) },
            { DocTypeReadVersion, nameof(DocTypeReadVersion) },
            { DocTypeExtension, nameof(DocTypeExtension) },
            { DocTypeExtensionName, nameof(DocTypeExtensionName) },
            { DocTypeExtensionVersion, nameof(DocTypeExtensionVersion) },
        };
    }

    public static void Test()
    {
        // Parse Matroska file
        try
        {
            // var file = @"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\test5.mkv";
            var file = @"D:\Users\danny\Downloads\matroska_test_w1_1\test5.mkv"; // start off simple
            var srt = ReadSrt();
            
            _stream = new BufferedStream(File.OpenRead(file));

            // step 1: reading the header
            // an ebml document always starts with a header containing the following 4 bytes: 0x1A45DFA3
            var masterElement = ReadElement();
            ConsumeMasterElement(masterElement);
            
            if(masterElement.Id != WellKnownIds.EBML) throw new MalformedDocumentException("Expected master elementId to be: 0x1A45DFA3");
            
            // step 2: read our segment
            var segment = ReadElement();
            ConsumeMasterElement(segment);

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

    public int ReadIntegerValue(Element element)
    {
        _stream.Seek(element.Position + element.HeaderSize, SeekOrigin.Begin);
        var buffer = new byte[element.Size.Data];

        return (int)ReadVInt().Data;
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
        var durationWidth = VInt.FromData(BitMask.SizeOf(duration));

        var blockDurationElement = new Element(
            new ElementId(MatroskaElementRegistry.MatroskaBlockDuration.Id!.Value),
            durationWidth,
            ElementType.UnsignedInteger,
            0,
            new BufferContentReader(duration)
        );

        var trackNumber = VInt.FromData(track);
        var relativeTimestamp = VInt.FromData(0);
        var flags = VInt.FromData(0);
        var text = Encoding.UTF8.GetBytes(segment.Text);

        var blockSize = VInt.FromData(
            trackNumber.Width + 
            relativeTimestamp.Width + 
            flags.Width + 
            text.Length
        );

        // https://matroska.sourceforge.net/technical/specs/index.html#block_structure
        var contentStream = new MemoryStream(new byte[blockSize.Data]);
        contentStream.Write(trackNumber.AsBytes());
        contentStream.Write(relativeTimestamp.AsBytes());
        contentStream.Write(flags.AsBytes());
        contentStream.Write(text);

        var blockElement = new Element(
            new ElementId(MatroskaElementRegistry.MatroskaBlock.Id!.Value),
            blockSize,
            ElementType.Binary,
            0,
            new BufferContentReader(contentStream)
        );

        var groupSize = BitMask.SizeOf(blockElement) + BitMask.SizeOf(blockDurationElement);

        var blockGroupElement = new Element(
            new ElementId(MatroskaElementRegistry.MatroskaBlockGroup.Id!.Value),
            VInt.FromData(groupSize),
            ElementType.Master,
            0,
            NoContentReader.Instance
        );
        
        blockElement.SetParent(blockGroupElement);
        blockDurationElement.SetParent(blockGroupElement);

        return blockGroupElement;
    }
    
    private static SrtFile ReadSrt()
    {
        var srtFile = @"D:\Users\danny\Videos\Subs\Planetes JP 1-26 [Netflix]\Planetes JP 1-26 [Netflix]\Planetes.S01E19.CC.ja.srt";
        using var stream = File.OpenRead(srtFile);
        return SrtFile.Parse(stream).GetAwaiter().GetResult();
    }

    private static void ConsumeMasterElement(Element masterElement)
    {
        if (masterElement.Type != ElementType.Master) throw new ArgumentException("Expected element with type Master!");
        
        var size = (ulong)masterElement.Size.Data;

        while (size > 0)
        {
            var element = ReadElement(masterElement);

            var headerSize = (ulong)BitMask.SizeOf(element.Id) + (ulong)BitMask.SizeOf(element.Size) + (ulong)element.Size.Data;
            size -= headerSize;

            if (element.IsVoid)
            {
                ConsumeUnknownElement(element);
                continue;
            }

            var matroskaElement = MatroskaElementRegistry.FindElement(element.Id);
            if (matroskaElement == null)
            {
                ConsumeUnknownElement(element);
                continue;
            }
                
            if (
                element.Type == ElementType.ASCIIString ||
                element.Type == ElementType.Utf8String
            )
            {
                var docType = element.Type == ElementType.ASCIIString ? 
                    ReadASCIIString(element) : 
                    ReadUTF8String(element);
                    
                continue;
            }

            if (element.Type == ElementType.UnsignedInteger)
            {
                var value = ReadUInt(element);
                continue;
            }

            if (element.Type == ElementType.Master)
            {
                ConsumeMasterElement(element);
                continue;
            }
            
            ConsumeUnknownElement(element);
        }

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
            var contentReader = element.Type == ElementType.Master ? NoContentReader.Instance : element.ContentReader;
            contentReader.ReadAsStream().CopyTo(target);
        }
    }

    private static Element ReadElement(Element parent = null)
    {
        var id = ReadElementId();
        var position = _stream.Position - BitMask.SizeOf(id);
        var width = ReadVInt();
        var contentPosition = position + BitMask.SizeOf(id) + BitMask.SizeOf(width);

        var type = ElementType.Unknown;

        if (
            id == WellKnownIds.Version ||
            id == WellKnownIds.ReadVersion ||
            id == WellKnownIds.MaxIdLength ||
            id == WellKnownIds.MaxSizeLength ||
            id == WellKnownIds.DocTypeVersion ||
            id == WellKnownIds.DocTypeReadVersion ||
            id == WellKnownIds.DocTypeExtensionVersion
        )
        {
            type = ElementType.UnsignedInteger;
        }

        if (
            id == WellKnownIds.DocType ||
            id == WellKnownIds.DocTypeExtension ||
            id == WellKnownIds.DocTypeExtensionName
        )
        {
            type = ElementType.ASCIIString;
        }

        if (
            id == WellKnownIds.EBML
        )
        {
            type = ElementType.Master;
        }

        var matroskaElement = MatroskaElementRegistry.FindElement(id);
        if (matroskaElement != null)
        {
            type = matroskaElement.Type switch
            {
                "integer" => ElementType.SignedInteger,
                "uinteger" => ElementType.UnsignedInteger,
                "float" => ElementType.Float,
                "string" => ElementType.ASCIIString,
                "date" => ElementType.Date,
                "utf-8" => ElementType.Utf8String,
                "master" => ElementType.Master,
                "binary" => ElementType.Binary,
                
                _=> ElementType.Unknown
            };
        }

        return new Element(
            id, 
            width,
            type,
            position,
            new StreamChunkContentReader(_stream, contentPosition, width.Data),
            parent
        );
    }
    
    private static ElementId ReadElementId()
    {
        // element ids are structured as vints with the vint marker being included
        var value = ReadVInt();
        DebugUtilities.DumpHex(value);
        
        return new ElementId(value);
    }

    private static string ReadASCIIString(Element element) => ReadString(element, Encoding.ASCII);

    private static string ReadUTF8String(Element element) => ReadString(element, Encoding.UTF8);

    private static string ReadString(Element element, Encoding encoding)
    {
        if (element.Size.Data == 0) return String.Empty;
        var bytes = ReadBytes(element.Size.Data);
        return encoding.GetString(bytes);
    }

    private static uint ReadUInt(Element element)
    {
        var bytes = ReadBytes(element.Size.Data);
        return ToUInt(bytes);
    }

    private static void ConsumeUnknownElement(Element element)
    {
        // simply move our stream forward
        ReadBytes(element.Size.Data);
    }

    /// <summary>
    /// Read an integer of variable length, anatomy consists of: width, marker bit, value
    ///
    /// the width of a variable integer is embedded in the first octet, the width is calculated by taking the sum of all '0' bits 
    ///
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-vint_data
    /// </summary>
    /// <returns></returns>
    private static VInt ReadVInt()
    {
        // the size of a vint is indicated by the first encountered `1` bit in an array of octets
        // for starting off, support only 1 octet
        // 1XXX XXXX -> 1
        // 01XX XXXX -> 2
        // 001X XXXX -> 3
        // 0001 XXXX -> 4
        // 0000 1XXX -> 5
        // 0000 01XX -> 6
        // 0000 001X -> 7
        // 0000 0001 -> 8
        
        // a vint always has a length of at least 1 octet
        long data = ReadBytes(1)[0];
        
        // https://www.rfc-editor.org/rfc/rfc8794#name-vint_width
        // step 1: determine width by finding our width marker
        var additionalOctetCount = 0;
        if (BitMask.IsSet(data, 7)) additionalOctetCount = 0;
        else if (BitMask.IsSet(data, 6)) additionalOctetCount = 1;
        else if (BitMask.IsSet(data, 5)) additionalOctetCount = 2;
        else if (BitMask.IsSet(data, 4)) additionalOctetCount = 3;
        else if (BitMask.IsSet(data, 3)) additionalOctetCount = 4;
        else if (BitMask.IsSet(data, 2)) additionalOctetCount = 5;
        else if (BitMask.IsSet(data, 1)) additionalOctetCount = 6;
        else if (BitMask.IsSet(data, 0)) additionalOctetCount = 7;

        // step 2: strip our marker bit
        // first octet is still part of our value, dont discard!
        data = BitMask.Unset(data, 7 - additionalOctetCount);
        if (additionalOctetCount == 0) return new VInt(1, data);

        // step 3: append our additional octets
        var additionalOctets = ReadBytes(additionalOctetCount);
        data <<= additionalOctetCount * 8;
        data |= ToLong(additionalOctets);

        return new VInt(additionalOctetCount + 1, data);
    }
    
    // can we do this with generic math? -> needs to implement the proper operators
    private static long ToLong(byte[] octets)
    {
        int value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
    
    private static int ToInt(byte[] octets)
    {
        int value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
    
    private static uint ToUInt(byte[] octets)
    {
        uint value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }

    private static byte[] ReadBytes(long count)
    {
        var bytes = new byte[count];
        _ = _stream.Read(bytes, 0, (int)count);
        return bytes;
    }
}


// TODO: Investigate 'Length' type as a bridge between different numeric types?

// structures representing the lowest individual aspects of our ebml documents

public interface IElement<TSelf, TValue> where TSelf : IElement<TSelf, TValue>
{

    ElementId Id { get; }
        
}

