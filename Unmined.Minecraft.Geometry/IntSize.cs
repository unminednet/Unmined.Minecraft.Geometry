using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer size
/// </summary>
[DebuggerStepThrough]
public readonly struct IntSize : IEquatable<IntSize>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public IntSize(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Width => X;
    public int Height => Z;

    public static bool operator ==(IntSize left, IntSize right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }


    public static bool operator !=(IntSize left, IntSize right)
    {
        return !(left == right);
    }

    public static IntSize operator +(IntSize left, IntVector right)
    {
        return new IntSize(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator IntSize(IntPoint intPoint)
    {
        return new IntSize(intPoint.X, intPoint.Z);
    }

    public static implicit operator IntSize(IntVector intVector)
    {
        return new IntSize(intVector.X, intVector.Z);
    }

    public static IntSize operator -(IntSize left, IntVector right)
    {
        return new IntSize(left.X - right.X, left.Z - right.Z);
    }

    public static IntSize Create(int x, int z)
    {
        return new IntSize(x, z);
    }

    public static bool Equals(IntSize a, IntSize b)
    {
        return a == b;
    }

    public static string ToString(int x, int z, string? format, IFormatProvider? formatProvider)
    {
        return $"({x.ToString(format, formatProvider)}\u00A0x\u00A0{z.ToString(format, formatProvider)})";
    }

    public override bool Equals(object? obj)
    {
        return obj is IntSize other && Equals(this, other);
    }

    public bool Equals(IntSize other)
    {
        return Equals(this, other);
    }


    public override int GetHashCode()
    {
        return ((X << 5) + X) ^ Z;
    }

    public override string ToString()
    {
        return ToString("D", CultureInfo.InvariantCulture);
    }

    public string ToString(IFormatProvider? formatProvider)
    {
        return ToString("D", formatProvider);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString(X, Z, format, formatProvider);
    }
}