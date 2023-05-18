namespace SubUtilities.Matroska;

static class DebugUtilities
{
    public static string DumpBinary(byte[] value) => String.Join(' ', value.Select( b => DumpBinary(b) ));

    public static string DumpBinary(byte value) => Convert.ToString(value, toBase: 2).PadLeft(8, '0');
    
    public static string DumpBinary(long value) => String.Join(' ', Convert.ToString(value, toBase: 2)
        .PadLeft(32, '0')
        .Chunk(8)
        .Select(x => String.Join("", x)));
    
    public static string DumpBinary(int value) => String.Join(' ', Convert.ToString(value, toBase: 2)
        .PadLeft(32, '0')
        .Chunk(8)
        .Select(x => String.Join("", x)));
    
    public static string DumpBinary(VInt value) => DumpBinary(value.Data | value.Marker);
    public static string DumpHex(VInt value) => DumpHex(value.Data | value.Marker);

    public static string DumpHex(long value)
    {
        var size = BitMask.SizeOf(value);
        var result = "0x";

        for (var i = size - 1; i >= 0; i--) result += Convert.ToString(BitMask.ReadOctet(value, i), toBase: 16).PadLeft(2, '0').ToUpper();

        return result;
    }
    
    public static string DumpDecimal(VInt value) => Convert.ToString(value.Data | value.Marker, toBase: 10);
}