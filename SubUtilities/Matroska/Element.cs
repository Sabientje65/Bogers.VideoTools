using System.Diagnostics;
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
        IContentReader contentReader,
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
        ContentReader = contentReader;
        _children = new List<Element>();
        
        SetParent(parent);
    }

    public readonly IContentReader ContentReader;

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
}