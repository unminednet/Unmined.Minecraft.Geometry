using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer region vector
/// </summary>
[DebuggerStepThrough]
public readonly struct RegionVector : IEquatable<RegionVector>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public RegionVector(int x, int z)
    {
        X = x;
        Z = z;
    }

    public static bool operator ==(RegionVector left, RegionVector right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }


    public static bool operator !=(RegionVector left, RegionVector right)
    {
        return !(left == right);
    }

    public static RegionVector operator +(RegionVector left, RegionVector right)
    {
        return new RegionVector(left.X + right.X, left.Z + right.Z);
    }

    public static implicit operator RegionVector(RegionPoint regionPoint)
    {
        return new RegionVector(regionPoint.X, regionPoint.Z);
    }

    public static implicit operator RegionVector(RegionSize regionSize)
    {
        return new RegionVector(regionSize.X, regionSize.Z);
    }

    public static RegionVector operator -(RegionVector left, RegionVector right)
    {
        return new RegionVector(left.X - right.X, left.Z - right.Z);
    }

    public static bool Equals(RegionVector a, RegionVector b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is RegionVector other && Equals(this, other);
    }

    public bool Equals(RegionVector other)
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
        return 'r' + IntPoint.ToString(X, Z, format, formatProvider);
    }
}