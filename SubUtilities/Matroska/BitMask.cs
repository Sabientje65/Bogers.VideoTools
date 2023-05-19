using System.Numerics;

namespace SubUtilities.Matroska;

static class BitMask
{
    /// <summary>
    /// Check if a '1' bit is present at the given position
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="position">Position to check</param>
    /// <typeparam name="TValue">Numeric type</typeparam>
    /// <returns>True when '1' bit is detected</returns>
    public static bool IsSet<TValue>(TValue value, int position)
        where TValue : IBitwiseOperators<TValue, TValue, TValue>,  // can perform bitwise ops with self
        IComparisonOperators<TValue, TValue, bool>, // can compare with self
        IShiftOperators<TValue, int, TValue>,       // can shift self with int resulting in self
        INumber<TValue>                             // contains 'one' and 'zero' statics
        => (value & (TValue.One << position)) != TValue.Zero;
    
    /// <summary>
    /// Check if a '0' bit is present at the given position
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="position">Position to check</param>
    /// <typeparam name="TValue">Numeric type</typeparam>
    /// <returns>True when '0' bit is detected</returns>
    public static bool IsUnset<TValue>(TValue value, int position)
        where TValue : IBitwiseOperators<TValue, TValue, TValue>, 
        IComparisonOperators<TValue, TValue, bool>,
        IShiftOperators<TValue, int, TValue>,
        INumber<TValue>
        => (value & (TValue.One << position)) == TValue.Zero;

    /// <summary>
    /// Sets a '1' bit at the given position
    /// </summary>
    /// <param name="value">Base value</param>
    /// <param name="position">Position to set bit at</param>
    /// <typeparam name="TValue">Input/output type</typeparam>
    /// <returns>Copy of <see cref="value"/> with bit at position <see cref="position"/> set to '1'</returns>
    public static TValue Set<TValue>(TValue value, int position)
        where TValue : IBitwiseOperators<TValue, TValue, TValue>,
        IShiftOperators<TValue, int, TValue>,
        INumber<TValue>
        => value | (TValue.One << position);
    
    /// <summary>
    /// Sets a '0' bit at the given position
    /// </summary>
    /// <param name="value">Base value</param>
    /// <param name="position">Position to set bit at</param>
    /// <typeparam name="TValue">Input/output type</typeparam>
    /// <returns>Copy of <see cref="value"/> with bit at position <see cref="position"/> set to '0'</returns>
    public static TValue Unset<TValue>(TValue value, int position)
        where TValue : IBitwiseOperators<TValue, TValue, TValue>,
        IShiftOperators<TValue, int, TValue>,
        INumber<TValue>
        => value & ~(TValue.One << position);



    // public static bool IsSet(long value, int pos) => (value & (1 << pos)) != 0;
    // public static bool IsSet(int value, int pos) => (value & (1 << pos)) != 0;
    // public static bool IsSet(byte value, int pos) => (value & (1 << pos)) != 0;
    // public static bool IsUnset(byte value, int pos) => (value & (1 << pos)) != 0;

    // public static long Set(long value, int pos) => value | (1 << pos);
    // public static int Set(int value, int pos) => value | (1 << pos);
    // public static byte Set(byte value, int pos) => (byte)(value | (1 << pos));
    
    // public static int Unset(int value, int pos) => (value & ~(1 << pos));
    // public static byte Unset(byte value, int pos) => (byte)(value & ~(1 << pos));

    // public static int PadLeft(int value, int bits) => (value << bits);
    // public static byte PadLeft(byte value, int bits) => (byte)(value << bits);

    /// <summary>
    /// Read the byte octet at the given position
    /// </summary>
    /// <param name="value">64 bit integer</param>
    /// <param name="octet">Octet position</param>
    /// <returns>Octet at given position</returns>
    public static byte ReadOctet(long value, int octet) => (byte)(value >> (octet * 8));
    
    /// <summary>
    /// Read the byte octet at the given position
    /// </summary>
    /// <param name="value">32 bit integer</param>
    /// <param name="octet">Octet position</param>
    /// <returns>Octet at given position</returns>
    public static byte ReadOctet(int value, int octet) => (byte)(value >> (octet * 8));
    
    /// <summary>
    /// Read the byte octet at the given position
    /// </summary>
    /// <param name="value">16 bit integer</param>
    /// <param name="octet">Octet position</param>
    /// <returns>Octet at given position</returns>
    public static byte ReadOctet(short value, int octet) => (byte)(value >> (octet * 8));

    /// <summary>
    /// Calculate the size in bytes of the given value
    /// </summary>
    /// <param name="value">unsigned 64 bit integer</param>
    /// <returns>Size in bytes</returns>
    public static byte SizeOf(ulong value)
    {
        if (value > (1L << 56)) return 8;
        if (value > (1L << 48)) return 7;
        if (value > (1L << 40)) return 6;
        if (value > (1L << 32)) return 5;
        if (value > (1L << 24)) return 4;
        if (value > (1L << 16)) return 3;
        if (value > (1L << 8)) return 2;
        return 1;
    }
    
    /// <summary>
    /// Calculate the size in bytes of the given value
    /// </summary>
    /// <param name="value">64 bit integer</param>
    /// <returns>Size in bytes</returns>
    public static byte SizeOf(long value)
    {
        if (value > (1L << 56)) return 8;
        if (value > (1L << 48)) return 7;
        if (value > (1L << 40)) return 6;
        if (value > (1L << 32)) return 5;
        if (value > (1L << 24)) return 4;
        if (value > (1L << 16)) return 3;
        if (value > (1L << 8)) return 2;
        return 1;
    }
    
    /// <summary>
    /// Calculate the size in bytes of the given value
    /// </summary>
    /// <param name="value">32 bit integer</param>
    /// <returns>Size in bytes</returns>
    public static byte SizeOf(int value)
    {
        if (value > (1 << 24)) return 4;
        if (value > (1 << 16)) return 3;
        if (value > (1 << 8)) return 2;
        return 1;
    }

    /// <summary>
    /// Calculate the size in bytes of the given value
    /// </summary>
    /// <param name="value">unsigned 32 bit integer</param>
    /// <returns>Size in bytes</returns>
    public static byte SizeOf(uint value)
    {
        if (value > (1 << 24)) return 4;
        if (value > (1 << 16)) return 3;
        if (value > (1 << 8)) return 2;
        return 1;
    }

    /// <summary>
    /// Calculate the size in bytes of an individual element, will not inspect content
    /// </summary>
    /// <param name="element">EBML Element</param>
    /// <returns>Size of the element</returns>
    public static long SizeOf(Element element) => SizeOf(element.Id) + SizeOf(element.Size) + element.Size.Data;
    
    public static int SizeOf(ElementId elementId) => elementId.AsVInt().Width;

    public static int SizeOf(VInt vint) => vint.Width;
}