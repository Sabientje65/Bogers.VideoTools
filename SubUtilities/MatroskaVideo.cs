using System.Collections;
using System.Text;

namespace SubUtilities;

// https://www.matroska.org/technical/subtitles.html
// https://matroska-org.github.io/libebml/specs.html
// https://www.rfc-editor.org/rfc/rfc8794.html
// For inspection, we can use a combination of https://mh-nexus.de/en/downloads.php?product=HxD20 and https://mkvtoolnix.download/downloads.html#windows

// EBML -> Define different datatypes, separate reader library?

public class MatroskaVideo
{
    private static Stream _stream;

    public static void Test()
    {
        // Parse Matroska file
        try
        {
            var file = @"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\test5.mkv";
            _stream = File.OpenRead(file);

            // step 1: reading the header
            // an ebml document always starts with a header containing the following 4 bytes: 0x1A45DFA3
            if (!VerifyMasterId()) throw new Exception("Expected master elementId to be: 0x1A45DFA3");
            
            // assume A3 -> 1
            var masterSize = ReadVInt();
            // var master = ReadVInt();
            
            // var masterValue = ReadBytes((int)masterSize);
            
            
            // var octet = ReadBytes(1)[0];
            // StringifyBits(octet);

            // step 2: read our element data size
            // https://www.rfc-editor.org/rfc/rfc8794#name-variable-size-integer
            // https://www.rfc-editor.org/rfc/rfc8794#name-element-data-size
            // encoded as a variable size integer

            // 18 - 1f -> matroska
            ReadBytes(0x17 - 0x4);
            var docType = DumpString(ReadBytes(0x8));
            if (!docType.Equals("matroska")) throw new Exception("Expected doctype to be 'matroska'");

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

    private static string DumpString(byte[] b) => String.Join(' ', b.Select( b => DumpString(b).PadLeft(8, '0') ));

    private static string DumpString(byte b) => Convert.ToString(b, toBase: 2).PadLeft(8, '0');
    
    class BitMask
    {
        public static bool IsSet(byte b, int pos) => (b & (1 << (pos - 1))) != 0;
        public static bool IsUnset(byte b, int pos) => (b & (1 << (pos - 1))) == 0;

        public static byte Set(byte b, int pos) => (byte)(b | (1 << (pos - 1)));
        public static byte Unset(byte b, int pos) => (byte)(b & ~(1 << (pos - 1)));

        public static byte PadLeft(byte b, int bits) => (byte)(b << bits);
    }

    private static int ReadVInt()
    {
        var width = ReadVIntValue();
        var data = ReadBytes((int)width);

        return BitConverter.ToInt32(data);
    }

    private static int ReadVIntValue()
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
        
        //A3 42 86 81 <-- hoe plukken we hier een version uit?

        var widthOctetCount = ReadBytes(1)[0];

        // https://www.rfc-editor.org/rfc/rfc8794#name-vint_width
        // step 1: determine width by finding our width marker
        var vintWidth = 0;
        if (BitMask.IsSet(widthOctetCount, 8)) vintWidth = 1;
        else if (BitMask.IsSet(widthOctetCount, 7)) vintWidth = 2;
        else if (BitMask.IsSet(widthOctetCount, 6)) vintWidth = 3;
        else if (BitMask.IsSet(widthOctetCount, 5)) vintWidth = 4;
        else if (BitMask.IsSet(widthOctetCount, 4)) vintWidth = 5;
        else if (BitMask.IsSet(widthOctetCount, 3)) vintWidth = 6;
        else if (BitMask.IsSet(widthOctetCount, 2)) vintWidth = 7;
        else if (BitMask.IsSet(widthOctetCount, 1)) vintWidth = 8;

        // unset marker bit - first octet is part of the octet count
        widthOctetCount = BitMask.Unset(widthOctetCount, 9 - vintWidth);
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

    private static bool VerifyMasterId()
    {
        var header = ReadBytes(4);

        return header[0] == 0x1a &&
            header[1] == 0x45 &&
            header[2] == 0xdf &&
            header[3] == 0xa3;
    }

    private static byte[] ReadBytes(int count)
    {
        if (count == 0) return Array.Empty<byte>();
        
        var bytes = new byte[count];
        _stream.Read(bytes, 0, count);
        return bytes;
    }
}