using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer point
/// </summary>
[DebuggerStepThrough]
public readonly struct IntPoint : IEquatable<IntPoint>, IFormattable
{
    public static IntPoint Empty = new(0, 0);

    public readonly int X;
    public readonly int Z;

    public IntPoint(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Left => X;
    public int Top => Z;

    public static bool operator ==(IntPoint left, IntPoint right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(IntPoint left, IntPoint right)
    {
        return !(left == right);
    }

    public static IntPoint operator +(IntPoint left, IntVector right)
    {
        return new IntPoint(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator IntPoint(IntVector intVector)
    {
        return new IntPoint(intVector.X, intVector.Z);
    }

    public static explicit operator IntPoint(IntSize intSize)
    {
        return new IntPoint(intSize.X, intSize.Z);
    }

    public static IntPoint operator -(IntPoint left, IntVector right)
    {
        return new IntPoint(left.X - right.X, left.Z - right.Z);
    }

    public static IntVector operator -(IntPoint left, IntPoint right)
    {
        return new IntVector(left.X - right.X, left.Z - right.Z);
    }

    public static IntPoint Create(int x, int z)
    {
        return new IntPoint(x, z);
    }

    public static bool Equals(IntPoint a, IntPoint b)
    {
        return a == b;
    }

    public static string ToString(int x, int z, string? format, IFormatProvider? formatProvider)
    {
        var numberFormatInfo = formatProvider != null
            ? NumberFormatInfo.GetInstance(formatProvider)
            : CultureInfo.InvariantCulture.NumberFormat;
        var separator = numberFormatInfo.NumberDecimalSeparator == "," || numberFormatInfo.NumberGroupSeparator == ","
            ? ";"
            : ",";
        return $"({x.ToString(format, numberFormatInfo)}{separator}\u00A0{z.ToString(format, numberFormatInfo)})";
    }

    public override bool Equals(object? obj)
    {
        return obj is IntPoint other && Equals(this, other);
    }

    public bool Equals(IntPoint other)
    {
        return
            X == other.X
            && Z == other.Z;
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

    public IntPoint WithX(int x)
    {
        return new IntPoint(x, Z);
    }

    public IntPoint WithZ(int z)
    {
        return new IntPoint(X, z);
    }
}