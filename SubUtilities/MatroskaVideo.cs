using System.Collections;
using System.Text;

namespace SubUtilities;

// https://www.matroska.org/technical/subtitles.html
// https://matroska-org.github.io/libebml/specs.html
// https://www.rfc-editor.org/rfc/rfc8794.html
// For inspection, we can use a combination of https://mh-nexus.de/en/downloads.php?product=HxD20 and https://mkvtoolnix.download/downloads.html#windows
// https://www.rfc-editor.org/rfc/rfc8794.pdf

// EBML -> Define different datatypes, separate reader library?

public class MatroskaVideo
{
    private static Stream _stream;

    // should generate this from spec
    private static class HeaderIds
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
            _stream = File.OpenRead(file);

            // step 1: reading the header
            // an ebml document always starts with a header containing the following 4 bytes: 0x1A45DFA3
            if (!VerifyMasterId()) throw new Exception("Expected master elementId to be: 0x1A45DFA3");
            
            // assume A3 -> 1
            var masterSize = ReadVInt();

            // general element layout:
            // element id
            // element size
            // element value
            
            while (masterSize > 0)
            {
                var elementId = ReadElementId();
                masterSize -= BitMask.SizeOf(elementId);
                
                var name = HeaderIds.Lookup[elementId];
                Console.Write("Detected " + name + ": ");
                
                if (
                    elementId == HeaderIds.DocType ||
                    elementId == HeaderIds.DocTypeExtension ||
                    elementId == HeaderIds.DocTypeExtensionName
                )
                {
                    var docType = ReadString();
                    Console.WriteLine(docType);
                    masterSize -= docType.Length;
                    masterSize--; // string length
                }

                if (
                    elementId == HeaderIds.Version ||
                    elementId == HeaderIds.ReadVersion ||
                    elementId == HeaderIds.MaxIdLength ||
                    elementId == HeaderIds.MaxSizeLength ||
                    elementId == HeaderIds.DocTypeVersion || 
                    elementId == HeaderIds.DocTypeReadVersion ||
                    elementId == HeaderIds.DocTypeExtensionVersion
                )
                {
                    var value = ReadUInt();
                    Console.WriteLine(value);
                    masterSize -= BitMask.SizeOf(value);
                    masterSize--; // account for width  
                }
            }

            // all master elements consist of 2 bytes
            // var elementId = ReadId(2);
            // var name = HeaderIds.Lookup[elementId];
            // if (elementId == HeaderIds.DocType)
            // {
            //     var docType = ReadString();
            //     Console.WriteLine("Detected doctype: " + docType);
            // }
            
            
            // https://www.matroska.org/technical/notes.html#example-of-segment-position, should skip the *length* we read for our first meaningful element?
            
            // var master = ReadVInt();
            
            // var masterValue = ReadBytes((int)masterSize);
            
            
            // var octet = ReadBytes(1)[0];
            // StringifyBits(octet);

            // step 2: read our element data size
            // https://www.rfc-editor.org/rfc/rfc8794#name-variable-size-integer
            // https://www.rfc-editor.org/rfc/rfc8794#name-element-data-size
            // encoded as a variable size integer

            // 18 - 1f -> matroska
            // ReadBytes(0x17 - 0x4);
            // var docType = DumpString(ReadBytes(0x8));
            // if (!docType.Equals("matroska")) throw new Exception("Expected doctype to be 'matroska'");

            // step 3: read our element data (binary data, other elements, or both)
        }
        finally
        {
            _stream.Dispose();
        }

        // first: what do we have... ?
        // var buffer = new byte[1024];
        // var bytes = stream.Read(buffer);
        //
        // var str = Encoding.UTF8.GetString(buffer);
        // var str2 = str; // allow setting breakpoint
    }

    class DebugUtilities
    {
        public static string DumpString(byte[] b) => String.Join(' ', b.Select( b => DumpString(b) ));
        
        public static string DumpString(int b) => String.Join(' ', Convert.ToString(b, toBase: 2)
            .PadLeft(32, '0')
            .Chunk(8)
            .Select(x => String.Join("", x)));
        public static string DumpString(byte b) => Convert.ToString(b, toBase: 2).PadLeft(8, '0');
    }
    
    class BitMask
    {
        public static bool IsSet(byte b, int pos) => (b & (1 << pos)) != 0;
        public static bool IsUnset(byte b, int pos) => (b & (1 << pos)) == 0;

        public static int Set(int b, int pos) => (b | (1 << pos));
        public static byte Set(byte b, int pos) => (byte)(b | (1 << pos));
        public static int Unset(int b, int pos) => (b & ~(1 << pos));
        public static byte Unset(byte b, int pos) => (byte)(b & ~(1 << pos));

        public static int PadLeft(int b, int bits) => (b << bits);
        public static byte PadLeft(byte b, int bits) => (byte)(b << bits);
        
        public static byte SizeOf(int elementId)
        {
            if (elementId > (1 << 24)) return 4;
            if (elementId > (1 << 16)) return 3;
            if (elementId > (1 << 8)) return 2;
            return 1;
        }
        
        public static byte SizeOf(uint elementId)
        {
            if (elementId > (1 << 24)) return 4;
            if (elementId > (1 << 16)) return 3;
            if (elementId > (1 << 8)) return 2;
            return 1;
        }
    }

    private static int ReadElementId()
    {
        // element ids are structured as vints with the vint marker being included
        var id = ReadVInt();
        var idSize = BitMask.SizeOf(id);
        
        // pos of idSize in most significant octet
        var idMarkerBit = idSize * 8 - idSize;
        
        // the width marker bit is part of an id restore it
        id = BitMask.Set(id, idMarkerBit);
        return id;
    }

    private static string ReadString()
    {
        var length = ReadVInt();
        var bytes = ReadBytes(length);
        return Encoding.UTF8.GetString(bytes);
    }

    private static uint ReadUInt()
    {
        var size = ReadVInt();
        var bytes = ReadBytes(size);
        return ToUInt(bytes);
    }

    private static int ReadVInt()
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
        var width = ReadBytes(1)[0];
        
        // https://www.rfc-editor.org/rfc/rfc8794#name-vint_width
        // step 1: determine width by finding our width marker
        var additionalOctetCount = 0;
        if (BitMask.IsSet(width, 7)) additionalOctetCount = 0;
        else if (BitMask.IsSet(width, 6)) additionalOctetCount = 1;
        else if (BitMask.IsSet(width, 5)) additionalOctetCount = 2;
        else if (BitMask.IsSet(width, 4)) additionalOctetCount = 3;
        else if (BitMask.IsSet(width, 3)) additionalOctetCount = 4;
        else if (BitMask.IsSet(width, 2)) additionalOctetCount = 5;
        else if (BitMask.IsSet(width, 1)) additionalOctetCount = 6;
        else if (BitMask.IsSet(width, 0)) additionalOctetCount = 7;

        // step 2: strip our marker bit
        // first octet is still part of our value, dont discard!
        int value = BitMask.Unset(width, 7 - additionalOctetCount);
        if (width == 0) return value;
        
        // step 3: append our additional octets
        var additionalOctets = ReadBytes(additionalOctetCount);
        value <<= additionalOctetCount * 8;
        value |= ToInt(additionalOctets);

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

    private static bool VerifyMasterId() => ReadElementId() == HeaderIds.EBML;

    private static byte[] ReadBytes(int count)
    {
        if (count == 0) return Array.Empty<byte>();
        
        var bytes = new byte[count];
        _stream.Read(bytes, 0, count);
        return bytes;
    }
}