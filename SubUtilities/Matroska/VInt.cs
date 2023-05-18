using System.ComponentModel;
using System.Diagnostics;

namespace SubUtilities.Matroska;

[DebuggerDisplay("{DebuggerView}")]
public struct VInt
{
    
    public VInt(int width, long data)
    {
        Data = data;
        Width = width;// BitMask.SizeOf(data); <-- yields incorrect results when marker is the only `1` bit in octet
        
        // total octets * octet size - total octets
        Marker = BitMask.Set( 0, Width * 8 - Width );
    }
        
    public readonly int Width;
        
    public readonly long Data;

    public readonly long Marker;

    // public static implicit operator int(VInt self) => self.Data;
        
    
    [DebuggerHidden]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DebuggerView => $"Hex: {DebugUtilities.DumpHex(this)}, Data: {Data}, Width: {Width}, Binary: {DebugUtilities.DumpBinary(this)}";
}