using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable double 3D point
/// </summary>
public readonly struct WorldPoint3D : IEquatable<WorldPoint3D>, IFormattable
{
    public WorldPoint3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public static string ToString(double x, double y, double z, string? format, IFormatProvider? formatProvider)
    {
        var numberFormatInfo = formatProvider != null
            ? NumberFormatInfo.GetInstance(formatProvider)
            : CultureInfo.InvariantCulture.NumberFormat;
        var separator = numberFormatInfo.NumberDecimalSeparator == "," || numberFormatInfo.NumberGroupSeparator == ","
            ? ";"
            : ",";
        var xs = x.ToString(format, numberFormatInfo);
        var zs = z.ToString(format, numberFormatInfo);
        var ys = y.ToString(format, numberFormatInfo);
        return $"({xs}{separator}\u00A0{zs}{separator}\u00A0{ys})";
    }

    public override bool Equals(object? obj)
    {
        return obj is WorldPoint3D other && Equals(other);
    }

    public bool Equals(WorldPoint3D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }


    public string ToString(IFormatProvider? formatProvider)
    {
        return ToString("G15", formatProvider);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString(X, Y, Z, format, formatProvider);
    }
}