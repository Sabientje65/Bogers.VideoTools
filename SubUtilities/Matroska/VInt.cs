using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace SubUtilities.Matroska;

[DebuggerDisplay("{DebuggerView}")]
public struct VInt
{
    
    public VInt(int width, long data)
    {
        Data = data;
        Width = width;// BitMask.SizeOf(data); <-- yields incorrect results when marker is the only `1` bit in octet
        
        // 1 -> 1000_0000
        // 2 -> 0100_0000
        // 3 -> 0010_0000
        // 4 -> 0001_0000
        // 5 -> 0000_1000
        // 6 -> 0000_0100
        // 7 -> 0000_0010
        // 8 -> 0000_0001

        // possible values are limited, just use a lookup table
        Marker = Width switch
        {
            1 => 0b1000_0000,
            2 => 0b0100_0000_0000_0000,
            3 => 0b0010_0000_0000_0000_0000_0000,
            4 => 0b0001_0000_0000_0000_0000_0000_0000_0000,
            5 => 0b0000_1000_0000_0000_0000_0000_0000_0000_0000_0000,
            6 => 0b0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
            7 => 0b0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
            8 => 0b0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
            _ => throw new ArgumentOutOfRangeException()
        };

        // // 8 = 8 * 8 = 64, 
        // // step 1: calculate final bit of our octet
        // var markerPosition = 8 * Width - 1;
        //
        // // // step 2: step back to the position matching our width in the given octet
        // markerPosition -= Width - 1;
        //
        // Marker = BitMask.Set<long>(0, markerPosition);

        // total octets * octet size - total octets
        // Marker = Width switch
        // {
        //     
        // }

        // Marker = Width switch
        // {
        //     8 => BitMask.Set<long>(0, 64 - 7), //
        //     _ => BitMask.Set<long>(0, Width * 8 - Width)
        // };

        // if (Width == 8) BitMask.Set<long>( 0, Width * 8 - Width )
        // else Marker = BitMask.Set<long>( 0, Width * 8 - Width );
    }

    /// <summary>
    /// Create a new vint from a raw value, width will be inferred
    /// </summary>
    /// <param name="data">VInt data</param>
    /// <returns>VInt representing giving data</returns>
    public static VInt FromData(long data) => new VInt(BitMask.SizeOf(data), data);
    
    public readonly int Width;
        
    public readonly long Data;

    public readonly long Marker;

    // public static implicit operator int(VInt self) => self.Data;
    public readonly byte[] AsBytes()
    {
        var bytes = new byte[Width];
        var value = Data | Marker;

        for (var octet = Width; octet > 0; octet--) bytes[Width - octet] = BitMask.ReadOctet(value, octet - 1);

        // bytes[0] = BitMask.ReadOctet(value, 0);
        // if(Width > 1) bytes[1] = BitMask.ReadOctet(value, 1);
        // if(Width > 2) bytes[2] = BitMask.ReadOctet(value, 2);
        // if(Width > 3) bytes[3] = BitMask.ReadOctet(value, 3);
        // if(Width > 4) bytes[4] = BitMask.ReadOctet(value, 4);
        // if(Width > 5) bytes[5] = BitMask.ReadOctet(value, 5);
        // if(Width > 6) bytes[6] = BitMask.ReadOctet(value, 6);
        // if(Width > 7) bytes[7] = BitMask.ReadOctet(value, 7);
        return bytes;
    }
    
    [DebuggerHidden]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string DebuggerView => $"Hex: {DebugUtilities.DumpHex(this)}, Data: {Data}, Width: {Width}, Binary: {DebugUtilities.DumpBinary(this)}";
}