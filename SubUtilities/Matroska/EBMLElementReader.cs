using SubUtilities.Generated;

namespace SubUtilities.Matroska;

public class EBMLElementReader
{
    private readonly Stream _stream;
    
    public EBMLElementReader(Stream source)
    {
        _stream = source;
    }

    public Element ReadRootElement()
    {
        if (!CanReadNextRootElement()) throw new InvalidOperationException("No more root elements left, please call CanConsumeNextRootElement to ensure a new root element can be read");
        
        var element = ReadElement();
        if (element.Type != ElementType.Master) throw new ArgumentException("Expected element with type Master!");
        
        FillMasterElementTree(element);

        return element;
    }

    /// <summary>
    /// Verify whether there are still root elements left to be read
    /// </summary>
    /// <returns>True when root elements can be read</returns>
    public bool CanReadNextRootElement() => _stream.Position != _stream.Length;
    
    private void FillMasterElementTree(Element masterElement)
    {
        var size = (ulong)masterElement.Size.Data;

        while (size > 0)
        {
            var element = ReadElement(masterElement);
            size -= (ulong)BitMask.SizeOf(element);

            switch (element.Type)
            {
                case ElementType.Master:
                {
                    FillMasterElementTree(element);
                    break;
                }

                default:
                {
                    SkipToNextElement(element);
                    break;
                }
            }
        }

    }


    private Element ReadElement(Element? parent = null)
    {
        var id = ReadElementId();
        var position = _stream.Position - BitMask.SizeOf(id);
        var width = ReadVInt();
        var contentPosition = position + BitMask.SizeOf(id) + BitMask.SizeOf(width);

        var type = ElementType.Unknown;

        if (
            id == WellKnownEBMLIds.Version ||
            id == WellKnownEBMLIds.ReadVersion ||
            id == WellKnownEBMLIds.MaxIdLength ||
            id == WellKnownEBMLIds.MaxSizeLength ||
            id == WellKnownEBMLIds.DocTypeVersion ||
            id == WellKnownEBMLIds.DocTypeReadVersion ||
            id == WellKnownEBMLIds.DocTypeExtensionVersion
        )
        {
            type = ElementType.UnsignedInteger;
        }

        if (
            id == WellKnownEBMLIds.DocType ||
            id == WellKnownEBMLIds.DocTypeExtension ||
            id == WellKnownEBMLIds.DocTypeExtensionName
        )
        {
            type = ElementType.ASCIIString;
        }

        if (
            id == WellKnownEBMLIds.EBML
        )
        {
            type = ElementType.Master;
        }

        var matroskaElement = MatroskaElementRegistry.FindElement(id);
        if (matroskaElement != null) type = matroskaElement.Type;

        return new Element(
            id, 
            width,
            type,
            position,
            new StreamChunkElementContent(_stream, contentPosition, width.Data),
            parent
        );
    }
    
    private ElementId ReadElementId()
    {
        // element ids are structured as vints with the vint marker being included
        var value = ReadVInt();
        
        return new ElementId(value);
    }
    
        
    // simply move our stream forward
    private void SkipToNextElement(Element element) => ReadBytes(element.Size.Data);

    // private string ReadASCIIString(Element element) => ReadString(element, Encoding.ASCII);
    //
    // private string ReadUTF8String(Element element) => ReadString(element, Encoding.UTF8);
    
    // private string ReadString(Element element, Encoding encoding)
    // {
    //     if (element.Size.Data == 0) return String.Empty;
    //     var bytes = ReadBytes(element.Size.Data);
    //     return encoding.GetString(bytes);
    // }
    //
    // private uint ReadUInt(Element element)
    // {
    //     var bytes = ReadBytes(element.Size.Data);
    //     return ToUInt(bytes);
    // }
    //
    // private int ToInt(byte[] octets)
    // {
    //     int value = 0;
    //     foreach (var octet in octets) value = (value << 8) | octet;
    //     return value;
    // }
    //
    // private uint ToUInt(byte[] octets)
    // {
    //     uint value = 0;
    //     foreach (var octet in octets) value = (value << 8) | octet;
    //     return value;
    // }

    /// <summary>
    /// Read an integer of variable length, anatomy consists of: width, marker bit, value
    ///
    /// the width of a variable integer is embedded in the first octet, the width is calculated by taking the sum of all '0' bits 
    ///
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-vint_data
    /// </summary>
    /// <returns></returns>
    private VInt ReadVInt()
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
    
    private byte[] ReadBytes(long count)
    {
        var bytes = new byte[count];
        _ = _stream.Read(bytes, 0, (int)count);
        return bytes;
    }
    
    // can we do this with generic math? -> needs to implement the proper operators
    private static long ToLong(byte[] octets)
    {
        int value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
}