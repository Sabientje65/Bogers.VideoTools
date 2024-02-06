using System.Diagnostics;
using System.Text;
using SubUtilities.Generated;

namespace SubUtilities.Matroska;

// abstract class? -> embed metadata, CanHaveChildElements, ShouldConsume, etc, etc.

public struct SizeChangedArgs
{
    public long SizeChange { get; }
        
    public SizeChangedArgs(long sizeChange)
    {
        SizeChange = sizeChange;
    }
}

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

    public IElementContent Content;

    public Element? Parent => _parent;

    public IReadOnlyList<Element> Children => _children;

    public readonly IMatroskaElement? MatroskaElement;
    
    public long Position;

    public readonly long NextSibling;

    public readonly ElementId Id;
    
    public readonly int HeaderSize;
    
    // todo: account for unknown sizes
    // see: https://www.rfc-editor.org/rfc/rfc8794.pdf#name-unknown-data-size
    public VInt Size;

    public readonly ElementType Type;

    public readonly bool IsUnknownSize;

    public readonly bool IsVoid;

    public string DebuggerView => $"Position: {DebugUtilities.DumpHex(Position)}, Type: {MatroskaElement?.GetType()?.Name}, Next sibling: {DebugUtilities.DumpHex(NextSibling)}";
    
    // public EventHandler<SizeChangedArgs> OnSizeChanged;

    private void SetParent(Element? parent)
    {
        _parent?._children.Remove(this);
        parent?._children.Add(this);
        _parent = parent;
    }
    
    // public void Reposition(long relativeOffset)
    // {
    //     Position += relativeOffset;
    //     foreach (var child in _children) child.Reposition(relativeOffset);
    //     FindNextSibling()?.Reposition(relativeOffset);
    // }
        
    private Element? FindPreviousSibling()
    {
        if (_parent == null) return null;
        var selfIdx = _parent._children.IndexOf(this);
        if (selfIdx - 1 < 0) return null;
            
        return _parent._children.Skip(selfIdx - 1).FirstOrDefault();
    } 

    private Element? FindNextSibling()
    {
        if (_parent == null) return null;
        var selfIdx = _parent._children.IndexOf(this);
        return _parent._children.Skip(selfIdx + 1).FirstOrDefault();
    }

    public void Add(Element childElement)
    {
        var isFromDifferentDocument = FindRoot() != childElement.FindRoot();
        
        Add(childElement, isFromDifferentDocument);
    }
    
    private void Add(Element childElement, bool isNew)
    {
        var previousSibling = _children.LastOrDefault();
        
        childElement.SetParent(this);

        // take previous sibling position as base -> 
        childElement.Position = Position + HeaderSize + 1;
        if (previousSibling != null) childElement.Position = previousSibling.Position + BitMask.SizeOf(previousSibling) + 1;

        // all succeeding elements should be pushed down by the size of our new element
        // all containing elements should grow with our new element having being added
        var childSize = VInt.FromData(BitMask.SizeOf(childElement));

        // start off repositioning all siblings to the right
        var elementsToReposition = new List<Element>();
        var elementsToGrow = new List<Element>();

        var currentParent = _parent;
        while (currentParent != null) currentParent._parent.Size += childSize;


        // childElement.Reposition();

        // if (isNew)
        // {
        //     var size = BitMask.SizeOf(childElement);
        //     var previousSibling = childElement.FindPreviousSibling();
        //
        //     if (previousSibling == null) childElement.Position = HeaderSize + 1;
        //     else childElement.Position = previousSibling.Position + BitMask.SizeOf(previousSibling) + 1;
        //     
        //     childElement.FindNextSibling()?.Reposition(size);
        //     OnSizeChanged(new SizeChangedArgs(childElement.HeaderSize + childElement.Size.Data));    
        // }
    }

    public Element? FindSingle(IMatroskaElement elementType) => FindMultiple(elementType).SingleOrDefault();

    public IEnumerable<Element> FindMultiple(IMatroskaElement elementType)
    {
        // depth first traversal
        var remaining = new Stack<Element>(_children);

        while (remaining.Any())
        {
            var current = remaining.Pop();
            if (current.Id == new ElementId(elementType.Id!.Value)) yield return current;
            foreach (var child in current._children) remaining.Push(child);
        }
    }

    private Element FindRoot() => _parent?.FindRoot() ?? _parent ?? this;


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

    private long ToLong(byte[] octets) => Utils.ToLong(octets);

    private ulong ToULong(byte[] octets) => Utils.ToULong(octets);

    private VInt CalculateSize()
    {
        long size = HeaderSize;

        // either content with a fixed size, or a parent with a dynamic size based on children
        if (!_children.Any()) size += this.Content.Size;
        else size += _children.Sum(c => c.CalculateSize().Data);
        
        return VInt.FromData(size);

    }

    // private void OnSizeChanged(SizeChangedArgs args)
    // {
    //     Size += VInt.FromData(args.SizeChange);
    //             
    //     // reposition siblings, since we've increased in size
    //     FindNextSibling()?.Reposition(args.SizeChange);
    //     _parent?.OnSizeChanged(args);
    //
    //     if (Id != MatroskaElementRegistry.MatroskaSegment.Id) return;
    //
    //     // if any of our seekheads changes size, we should trigger a re-index at the end
    //     // var shouldReindex = false;
    //             
    //     // for segments, we also want to update our seekhead positions
    //     foreach (var seekPosition in FindMultiple(MatroskaElementRegistry.MatroskaSeekPosition))
    //     {
    //         var currentPosition = seekPosition.ReadUIntContent();
    //         var newPosition = currentPosition + (ulong)args.SizeChange;
    //         var newContent = new BufferElementContent(newPosition);
    //         // shouldReindex = shouldReindex || seekPosition._ebmlElement.Content.Size != newContent.Size;
    //         seekPosition.Content = newContent;
    //                 
    //     }
    // }
}