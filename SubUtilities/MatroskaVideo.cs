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

        public static byte SizeOf(int elementId)
        {
            if (elementId > (1 << 24)) return 4;
            if (elementId > (1 << 16)) return 3;
            if (elementId > (1 << 8)) return 2;
            return 1;
        }

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
            var file = @"D:\Users\danny\Downloads\matroska_test_w1_1\test1.mkv"; // start off simple
            _stream = File.OpenRead(file);

            // step 1: reading the header
            // an ebml document always starts with a header containing the following 4 bytes: 0x1A45DFA3
            if (!VerifyMasterId()) throw new Exception("Expected master elementId to be: 0x1A45DFA3");
            
            // assume A3 -> 1
            var masterSize = ReadVInt();

            while (masterSize > 0)
            {
                var elementId = ReadId(2);
                masterSize -= 2;
                
                var name = HeaderIds.Lookup[elementId];
                Console.Write("Detected " + name + ": ");
                
                if (elementId == HeaderIds.DocType)
                {
                    var docType = ReadString();
                    Console.WriteLine(docType);
                    masterSize -= docType.Length + 1;
                }

                if (elementId == HeaderIds.DocTypeVersion)
                {
                    var version = ReadVInt();
                    Console.WriteLine(version);
                    masterSize -= HeaderIds.SizeOf(version);
                    
                    // todo: remove
                    ReadBytes(1);
                    masterSize -= 1;
                }

                if (elementId == HeaderIds.DocTypeReadVersion)
                {
                    var version = ReadVInt();
                    Console.WriteLine(version);
                    masterSize -= HeaderIds.SizeOf(version);
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

    private static string DumpString(byte[] b) => String.Join(' ', b.Select( b => DumpString(b) ));

    private static string DumpString(byte b) => Convert.ToString(b, toBase: 2).PadLeft(8, '0');
    
    class BitMask
    {
        public static bool IsSet(byte b, int pos) => (b & (1 << (pos))) != 0;
        public static bool IsUnset(byte b, int pos) => (b & (1 << (pos))) == 0;

        public static byte Set(byte b, int pos) => (byte)(b | (1 << (pos)));
        public static byte Unset(byte b, int pos) => (byte)(b & ~(1 << (pos)));

        public static byte PadLeft(byte b, int bits) => (byte)(b << bits);
    }

    // private static int ReadVInt()
    // {
    //     var width = ReadVIntValue();
    //     var data = ReadBytes((int)width);
    //
    //     return BitConverter.ToInt32(data);
    // }

    private static int ReadId(int size)
    {
        var bytes = ReadBytes(size);
        int result = bytes[0];
        
        // shift current octet to the left, or in the next octet
        for (var index = 1; index < size; index++) result = (result << 8) | bytes[index];
        return result;
    }

    private static string ReadString()
    {
        var length = ReadVInt();
        var bytes = ReadBytes(length);
        return Encoding.UTF8.GetString(bytes);
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
        
        var widthOctetCount = ReadBytes(1)[0];

        // https://www.rfc-editor.org/rfc/rfc8794#name-vint_width
        // step 1: determine width by finding our width marker
        var vintWidth = 0;
        if (BitMask.IsSet(widthOctetCount, 7)) vintWidth = 1;
        else if (BitMask.IsSet(widthOctetCount, 6)) vintWidth = 2;
        else if (BitMask.IsSet(widthOctetCount, 5)) vintWidth = 3;
        else if (BitMask.IsSet(widthOctetCount, 4)) vintWidth = 4;
        else if (BitMask.IsSet(widthOctetCount, 3)) vintWidth = 5;
        else if (BitMask.IsSet(widthOctetCount, 2)) vintWidth = 6;
        else if (BitMask.IsSet(widthOctetCount, 1)) vintWidth = 7;
        else if (BitMask.IsSet(widthOctetCount, 0)) vintWidth = 8;

        // unset marker bit - first octet is part of the octet count
        widthOctetCount = BitMask.Unset(widthOctetCount, 8 - vintWidth);
        vintWidth--;

        // throw when 0
        
        // include width octet, remove 1
        var vintValueOctets = new byte[4];
        var additionalWidthOctets = ReadBytes(vintWidth);
        
        // big endian, right to left
        // for ()
        
        // big endian - largest value first
        vintValueOctets[0] = BitMask.PadLeft(widthOctetCount, vintWidth);
        var octets = DumpString(vintValueOctets);

        for (var octetIdx = 1; octetIdx < additionalWidthOctets.Length; octetIdx++) vintValueOctets[octetIdx] = additionalWidthOctets[octetIdx];
        
        
        // var vintValueBytes = vintWidthBytes
        //     .Concat(ReadBytes(vintWidth - 1))
        //     .Concat(Enumerable.Range( 0, 8 - vintWidth ).Select(x => (byte)0)) // ensure proper length for 64 bit int
        //     .ToArray();
        // var vintValueArr = new BitArray(vintWidthOctets);

        // value = big endian
        // if (BitConverter.IsLittleEndian) Array.Reverse(octets);
        // for (var idx = 0; idx < vintWidth; idx++) vintValueArr.Set(7 - idx, false);

        // var vintValue = new byte[8];
        // vintValueArr.CopyTo(vintValue, 0);
        
        var value = BitConverter.ToInt32(vintValueOctets);
        
        // strip the width indicator bytes
        return value; 

        // var octetsArr = new BitArray(octets);

        // mark all width octets as 0


        // var data = new BitArray(vintWidth);
        // data.Or(vintWidthArr);


        // our width marker is part of our actual result

    }

    // private static int ReadDataSizeInOctets()
    // {
    //     // start with support for size in a single octet
    //     var sizeByte = ReadBytes(1);
    //     var bitArr = new BitArray(sizeByte);
    //
    //     if (bitArr.Get(7)) return 7;
    //     if (bitArr.Get(6)) return 6;
    //     if (bitArr.Get(5)) return 5;
    //     if (bitArr.Get(4)) return 4;
    //     if (bitArr.Get(3)) return 3;
    //     if (bitArr.Get(2)) return 2;
    //     if (bitArr.Get(1)) return 1;
    //     return 0; // invalid
    // }

    // private static int ReadHeaderElement(int elementId)
    // {
    //     var size = HeaderIds.SizeOf(elementId);
    //     var element = ReadBytes(size);
    //
    //     var value = element;
    // }

    private static bool VerifyMasterId()
    {
        return ReadId(4) == HeaderIds.EBML;
        
        // var header = ReadBytes(4);
        //
        // return header[0] == 0x1a &&
        //     header[1] == 0x45 &&
        //     header[2] == 0xdf &&
        //     header[3] == 0xa3;
    }

    private static byte[] ReadBytes(int count)
    {
        if (count == 0) return Array.Empty<byte>();
        
        var bytes = new byte[count];
        _stream.Read(bytes, 0, count);
        return bytes;
    }
}