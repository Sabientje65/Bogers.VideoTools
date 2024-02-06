namespace SubUtilities.Matroska;

public class Utils
{
    /// <summary>
    /// Parse the given set of bytes as a signed long
    /// </summary>
    /// <param name="octets"></param>
    /// <returns></returns>
    public static long ToLong(byte[] octets)
    {
        int value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
    
    /// <summary>
    /// Parse the given set of bytes as an unsigned long
    /// </summary>
    /// <param name="octets"></param>
    /// <returns></returns>
    public static ulong ToULong(byte[] octets)
    {
        uint value = 0;
        foreach (var octet in octets) value = (value << 8) | octet;
        return value;
    }
}