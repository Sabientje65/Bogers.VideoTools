using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
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

    public class MalformedDocumentException : Exception
    {
        public MalformedDocumentException(string message) : base(message)
        {
        }
        
        public MalformedDocumentException(string message, string documentationLink) : base(
            message + "\r\n" + "For more information, see: " + documentationLink
        )
        {
        }
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
            var masterElement = ReadElement();
            
            if(masterElement.Id != HeaderIds.EBML) throw new MalformedDocumentException("Expected master elementId to be: 0x1A45DFA3");
            
            // if (!VerifyMasterId()) throw new Exception("Expected master elementId to be: 0x1A45DFA3");
            //
            // // assume A3 -> 1
            var masterSize = masterElement.Size.Data;

            // general element layout:
            // element id
            // element size
            // element value
            
            while (masterSize > 0)
            {
                var element = ReadElement();
                masterSize -= BitMask.SizeOf(element.Id);
                masterSize -= BitMask.SizeOf(element.Size) + element.Size.Data;
                
                var name = HeaderIds.Lookup[element.Id];
                Console.Write("Detected " + name + ": ");
                
                if (
                    element.Type == ElementType.ASCIIString ||
                    element.Type == ElementType.Utf8String
                )
                {
                    var docType = element.Type == ElementType.ASCIIString ? 
                        ReadASCIIString(element) : 
                        ReadUTF8String(element);
                    
                    Console.WriteLine(docType);
                    
                    continue;
                }

                if (element.Type == ElementType.UnsignedInteger)
                {
                    var value = ReadUInt(element);
                    Console.WriteLine(value);
                    
                    continue;
                }
                
                ConsumeUnknownElement(element);
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
    }

    private static Element ReadElement()
    {
        var id = ReadElementId();
        var width = ReadVInt();
        var type = ElementType.Unknown;

        if (
            id == HeaderIds.Version ||
            id == HeaderIds.ReadVersion ||
            id == HeaderIds.MaxIdLength ||
            id == HeaderIds.MaxSizeLength ||
            id == HeaderIds.DocTypeVersion ||
            id == HeaderIds.DocTypeReadVersion ||
            id == HeaderIds.DocTypeExtensionVersion
        )
        {
            type = ElementType.UnsignedInteger;
        }

        if (
            id == HeaderIds.DocType ||
            id == HeaderIds.DocTypeExtension ||
            id == HeaderIds.DocTypeExtensionName
        )
        {
            type = ElementType.ASCIIString;
        }

        if (
            id == HeaderIds.EBML
        )
        {
            type = ElementType.Master;
        }

        return new Element(id, width, type);
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
        if (element.Type != ElementType.Unknown) throw new InvalidOperationException("Expected unknown element!");

        if (_stream.CanSeek) _stream.Seek(element.Size.Data, SeekOrigin.Current);
        else throw new InvalidOperationException("Expected a seekable stream!");
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
        int data = ReadBytes(1)[0];
        
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
        if (additionalOctetCount == 0) return new VInt(data);

        // step 3: append our additional octets
        var additionalOctets = ReadBytes(additionalOctetCount);
        data <<= additionalOctetCount * 8;
        data |= ToInt(additionalOctets);

        return new VInt(data);
    }
    
    // can we do this with generic math? -> needs to implement the proper operators
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

    private static byte[] ReadBytes(int count)
    {
        if (count == 0) return Array.Empty<byte>();
        
        var bytes = new byte[count];
        
        // FIXME: Account for signage bit
        _stream.Read(bytes, 0, count);
        return bytes;
    }
}

static class DebugUtilities
{
    public static string DumpBinary(byte[] value) => String.Join(' ', value.Select( b => DumpBinary(b) ));

    public static string DumpBinary(byte value) => Convert.ToString(value, toBase: 2).PadLeft(8, '0');
    
    public static string DumpBinary(int value) => String.Join(' ', Convert.ToString(value, toBase: 2)
        .PadLeft(32, '0')
        .Chunk(8)
        .Select(x => String.Join("", x)));
    public static string DumpBinary(VInt value) => DumpBinary(value.Data | value.Marker);

    public static string DumpHex(VInt value)
    {
        var fullValue = value.Data | value.Marker;
        var size = BitMask.SizeOf(fullValue);
        var result = "0x";

        // step 1: shift the octet to convert to the front
        // step 2: convert to a byte as to only consume the first octet
        // step 3: convert to hex representation
        for (var i = size - 1; i >= 0; i--) result += Convert.ToString((byte)(fullValue >> (i * 8)), toBase: 16).ToUpper();

        return result;
    }
    
    public static string DumpDecimal(VInt value) => Convert.ToString(value.Data | value.Marker, toBase: 10);
}

static class BitMask
{
    // generic math variants :-) for fun <-- not enough interop between different numeric types sadge
    // IConvertable X -> Y?
    
    // public static bool IsSet<TNumber>(TNumber value, int position)
    //     where TNumber : IShiftOperators<TNumber, int, TNumber>,
    //                     IBitwiseOperators<TNumber, int, TNumber>,
    //                     IComparisonOperators<TNumber, int, bool>
    //     => (value & (1 << position)) != 0;

    // public static TNumber Set<TNumber>(TNumber value, int position)
    //     where TNumber : IShiftOperators<TNumber, int, TNumber>,
    //     IBitwiseOperators<TNumber, int, TNumber>
    //     => value | (1 << position);
    //
    // public static TNumber Unset<TNumber>(TNumber value, int position)
    //     where TNumber : IShiftOperators<TNumber, int, TNumber>,
    //     IBitwiseOperators<TNumber, int, TNumber>
    //     => value | ~(1 << position);
    
    public static bool IsSet(int value, int pos) => (value & (1 << pos)) != 0;
    public static bool IsSet(byte value, int pos) => (value & (1 << pos)) != 0;
    public static bool IsUnset(byte value, int pos) => (value & (1 << pos)) == 0;

    public static long Set(long value, int pos) => value | (1 << pos);
    public static int Set(int value, int pos) => value | (1 << pos);
    public static byte Set(byte value, int pos) => (byte)(value | (1 << pos));
    
    public static int Unset(int value, int pos) => (value & ~(1 << pos));
    public static byte Unset(byte value, int pos) => (byte)(value & ~(1 << pos));

    public static int PadLeft(int value, int bits) => (value << bits);
    public static byte PadLeft(byte value, int bits) => (byte)(value << bits);
        
    
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
    
    public static int SizeOf(ElementId elementId) => elementId.AsVInt().Width;

    public static int SizeOf(VInt vint) => vint.Width;
}

// TODO: Investigate 'Length' type as a bridge between different numeric types?

// structures representing the lowest individual aspects of our ebml documents

public interface IElement<TSelf, TValue> where TSelf : IElement<TSelf, TValue>
{

    ElementId Id { get; }
        
}

public struct Element
{
    public Element(ElementId id, VInt size, ElementType type)
    {
        Id = id;
        Size = size;
        Type = type;
    }

    public readonly ElementId Id;
    
    // todo: account for unknown sizes
    // see: https://www.rfc-editor.org/rfc/rfc8794.pdf#name-unknown-data-size
    public readonly VInt Size;

    public readonly ElementType Type;
}

[DebuggerDisplay("{DebuggerView()}")]
public struct ElementId
{

    private readonly ulong _value;
        
    // public ElementId(uint value)
    // {
    //     _value = value;
    // }
        
    // FIXME: Don't allow casts to long/int, invalid types
        
    public ElementId(long value) => _value = (ulong)value;
    public ElementId(ulong value) => _value = value;
    public ElementId(int value) => _value = (ulong)(value);
    public ElementId(VInt value) => _value = (ulong)(value.Data | value.Marker);

    public static implicit operator ulong(ElementId e) => e._value;
    public static implicit operator long(ElementId e) => (long)e._value;
    public static implicit operator int(ElementId e) => (int)e._value;

    public VInt AsVInt() => new VInt((int)_value);
    
    [DebuggerHidden]
    private string DebuggerView() => $"Hex: {DebugUtilities.DumpHex(AsVInt())}, Binary: {DebugUtilities.DumpBinary(AsVInt())}";
    // public static implicit operator uint(ElementId e) => (uint)e._value;

    // public static implicit operator ElementId(ulong value) => new ElementId(value);
    // public static implicit operator ElementId(uint value) => new ElementId(value);
}
    
[DebuggerDisplay("{DebuggerView()}")]
public struct VInt
{
    
    public VInt(int data)
    {
        Data = data;
        Width = BitMask.SizeOf(data);
        
        // total octets * octet size - total octets
        Marker = BitMask.Set( 0, (Width * 8) - Width );
    }
        
    public readonly int Width;
        
    public readonly int Data;

    public readonly int Marker;

    // public static implicit operator int(VInt self) => self.Data;
        
    [DebuggerHidden]
    private string DebuggerView() => $"Hex: {DebugUtilities.DumpHex(this)}, Data: {Data}, Width: {Width}, Binary: {DebugUtilities.DumpBinary(this)}";
}

// abstract class? -> embed metadata, CanHaveChildElements, ShouldConsume, etc, etc.
public enum ElementType
{
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-signed-integer-element
    /// </summary>
    SignedInteger,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-unsigned-integer-element
    /// </summary>
    UnsignedInteger,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-float-element
    /// </summary>
    Float,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-string-element
    /// </summary>
    ASCIIString,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-utf-8-element
    /// </summary>
    Utf8String,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-date-element
    /// </summary>
    Date,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-master-element
    /// </summary>
    Master,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-binary-element
    /// </summary>
    Binary,
    
    /// <summary>
    /// Unknown element type, can be consumed but not meaningfully used
    /// </summary>
    Unknown
}