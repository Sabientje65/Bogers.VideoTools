using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using SubUtilities.Generated;

namespace SubUtilities.Matroska;

// abstract class? -> embed metadata, CanHaveChildElements, ShouldConsume, etc, etc.

[DebuggerDisplay("{DebuggerView}")]
public class Element
{
    private List<Element> _children;
    private Element? _parent;

    public Element(
        ElementId id, 
        VInt size, 
        ElementType type,
        long position,
        IElementContent content,
        Element? parent = null
    )
    {
        Id = id;
        Size = size;
        Type = type;

        // all bits set to 1
        var isUnknownSize = size.Data == 0b1111_1111_1111_1111; 
        // Enumerable.Range(0, 16)
        // .All(x => BitMask.IsSet(size.Data, x));

        IsUnknownSize = isUnknownSize;
        IsVoid = id == 0xEC;
        Position = position;
        MatroskaElement = MatroskaElementRegistry.FindElement(id);
        HeaderSize = BitMask.SizeOf(Size) + BitMask.SizeOf(Id);
        NextSibling = position + HeaderSize;
        Content = content;
        _children = new List<Element>();
        
        SetParent(parent);
    }

    public readonly IElementContent Content;

    public Element? Parent => _parent;

    public IReadOnlyList<Element> Children => _children;

    public readonly IMatroskaElement? MatroskaElement;
    
    public readonly long Position;

    public readonly long NextSibling;

    public readonly ElementId Id;
    
    public readonly int HeaderSize;
    
    // todo: account for unknown sizes
    // see: https://www.rfc-editor.org/rfc/rfc8794.pdf#name-unknown-data-size
    public readonly VInt Size;

    public readonly ElementType Type;

    public readonly bool IsUnknownSize;

    public readonly bool IsVoid;

    public string DebuggerView => $"Position: {DebugUtilities.DumpHex(Position)}, Type: {MatroskaElement?.GetType()?.Name}, Next sibling: {DebugUtilities.DumpHex(NextSibling)}";

    public void SetParent(Element? parent)
    {
        _parent?._children.Remove(this);
        parent?._children.Add(this);
        _parent = parent;
    }

    
    // should content reading be part of IElementContent? Maybe even just via a set of extension methods?
    public string ReadStringContent() => Type switch
    {
        ElementType.Utf8String => ReadString(Encoding.UTF8),
        ElementType.ASCIIString => ReadString(Encoding.ASCII),
        _ => throw new InvalidOperationException("ReadStringContent can only be invoked on elements of type UTF8String or ASCIIString")
    };

    public ulong ReadUIntContent()
    {
        if (Type != ElementType.UnsignedInteger) throw new InvalidOperationException("ReadUIntContent can only be invoked on elements of type UnsignedInteger");
        
        var bytes = Content.ReadAsBytes();
        return ToULong(bytes);
    }

    public long ReadIntContent()
    {
        if (Type != ElementType.SignedInteger) throw new InvalidOperationException("ReadIntContent can only be invoked on elements of type SignedInteger");
        
        var bytes = Content.ReadAsBytes();
        return ToLong(bytes);
    }
    
    private string ReadString(Encoding encoding)
    {
        if (Size.Data == 0) return String.Empty;
        var stream = Content.ReadAsBytes();
        return encoding.GetString(stream);
    }
    
    private long ToLong(byte[] octets)
    {
        int value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
    
    private ulong ToULong(byte[] octets)
    {
        uint value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
}