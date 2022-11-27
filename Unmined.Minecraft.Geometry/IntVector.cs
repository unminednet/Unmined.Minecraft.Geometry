using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer vector
/// </summary>
[DebuggerStepThrough]
public readonly struct IntVector : IEquatable<IntVector>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public IntVector(int x, int z)
    {
        X = x;
        Z = z;
    }

    public static bool operator ==(IntVector left, IntVector right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(IntVector left, IntVector right)
    {
        return !(left == right);
    }

    public static IntVector operator +(IntVector left, IntVector right)
    {
        return new IntVector(left.X + right.X, left.Z + right.Z);
    }

    public static implicit operator IntVector(IntPoint intPoint)
    {
        return new IntVector(intPoint.X, intPoint.Z);
    }

    public static implicit operator IntVector(IntSize intSize)
    {
        return new IntVector(intSize.X, intSize.Z);
    }

    public static IntVector operator -(IntVector left, IntVector right)
    {
        return new IntVector(left.X - right.X, left.Z - right.Z);
    }

    public static bool Equals(IntVector a, IntVector b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is IntVector other && Equals(this, other);
    }

    public bool Equals(IntVector other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        return ((X << 5) + X) ^ Z;
    }


    public double GetLength()
    {
        var x = (double)X;
        var z = (double)Z;
        return Math.Sqrt(x * x + z * z);
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
        return IntPoint.ToString(X, Z, format, formatProvider);
    }
}