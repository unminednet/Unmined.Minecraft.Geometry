using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer region size
/// </summary>
[DebuggerStepThrough]
public readonly struct RegionSize : IEquatable<RegionSize>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public RegionSize(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Width => X;
    public int Height => Z;

    public static bool operator ==(RegionSize left, RegionSize right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(RegionSize left, RegionSize right)
    {
        return !(left == right);
    }


    public static RegionSize operator +(RegionSize left, RegionVector right)
    {
        return new RegionSize(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator RegionSize(RegionPoint regionPoint)
    {
        return new RegionSize(regionPoint.X, regionPoint.Z);
    }

    public static implicit operator RegionSize(RegionVector regionVector)
    {
        return new RegionSize(regionVector.X, regionVector.Z);
    }

    public static RegionSize operator -(RegionSize left, RegionVector right)
    {
        return new RegionSize(left.X - right.X, left.Z - right.Z);
    }

    public static RegionSize Create(int x, int z)
    {
        return new RegionSize(x, z);
    }

    public static bool Equals(RegionSize a, RegionSize b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is RegionSize other && Equals(this, other);
    }

    public bool Equals(RegionSize other)
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
        return 'r' + IntSize.ToString(X, Z, format, formatProvider);
    }
}