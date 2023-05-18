using System.ComponentModel;
using System.Diagnostics;

namespace SubUtilities.Matroska;

[DebuggerDisplay("{DebuggerView}")]
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

    public VInt AsVInt() => new VInt(BitMask.SizeOf(_value), (int)_value);
    
    
    [DebuggerHidden]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private string DebuggerView => $"Hex: {DebugUtilities.DumpHex(AsVInt())}, Binary: {DebugUtilities.DumpBinary(AsVInt())}";
    // public static implicit operator uint(ElementId e) => (uint)e._value;

    // public static implicit operator ElementId(ulong value) => new ElementId(value);
    // public static implicit operator ElementId(uint value) => new ElementId(value);
}