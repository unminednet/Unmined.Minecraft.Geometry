using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer region point
/// </summary>
[DebuggerStepThrough]
public readonly struct RegionPoint : IEquatable<RegionPoint>, IFormattable
{
    public static RegionPoint Empty = new(0, 0);
    public readonly int X;


    public readonly int Z;

    public RegionPoint(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Left => X;


    public int Top => Z;

    public static bool operator ==(RegionPoint left, RegionPoint right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(RegionPoint left, RegionPoint right)
    {
        return !(left == right);
    }

    public static RegionPoint operator +(RegionPoint left, RegionVector right)
    {
        return new RegionPoint(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator RegionPoint(RegionVector regionVector)
    {
        return new RegionPoint(regionVector.X, regionVector.Z);
    }

    public static explicit operator RegionPoint(RegionSize regionSize)
    {
        return new RegionPoint(regionSize.X, regionSize.Z);
    }

    public static RegionPoint operator -(RegionPoint left, RegionVector right)
    {
        return new RegionPoint(left.X - right.X, left.Z - right.Z);
    }

    public static RegionVector operator -(RegionPoint left, RegionPoint right)
    {
        return new RegionVector(left.X - right.X, left.Z - right.Z);
    }

    public static RegionPoint Create(int x, int z)
    {
        return new RegionPoint(x, z);
    }

    public static bool Equals(RegionPoint a, RegionPoint b)
    {
        return a == b;
    }

    public double DistanceTo(RegionPoint other)
    {
        var x = X - other.X;
        var z = Z - other.Z;
        return
            Math.Sqrt(x * x + z * z);
    }

    public override bool Equals(object? obj)
    {
        return obj is RegionPoint other && Equals(this, other);
    }

    public bool Equals(RegionPoint other)
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
        return 'r' + IntPoint.ToString(X, Z, format, formatProvider);
    }

    public RegionPoint WithX(int x)
    {
        return new RegionPoint(x, Z);
    }

    public RegionPoint WithZ(int z)
    {
        return new RegionPoint(X, z);
    }
}