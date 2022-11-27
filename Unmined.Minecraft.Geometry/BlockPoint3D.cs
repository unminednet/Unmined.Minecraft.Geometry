using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer 3D block point
/// </summary>
[DebuggerStepThrough]
public readonly struct BlockPoint3D : IEquatable<BlockPoint3D>, IFormattable
{
    public static BlockPoint3D Empty = new(0, 0, 0);

    public readonly int X;
    public readonly int Z;
    public readonly int Y;

    public BlockPoint3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }


    public static bool operator ==(BlockPoint3D left, BlockPoint3D right)
    {
        return
            left.X == right.X
            && left.Y == right.Y
            && left.Z == right.Z ;
    }

    public static bool operator !=(BlockPoint3D left, BlockPoint3D right)
    {
        return !(left == right);
    }

    public static bool Equals(BlockPoint3D a, BlockPoint3D b)
    {
        return a == b;
    }

    public static string ToString(int x, int y, int z, string? format, IFormatProvider? formatProvider)
    {
        var numberFormatInfo = formatProvider != null
            ? NumberFormatInfo.GetInstance(formatProvider)
            : CultureInfo.InvariantCulture.NumberFormat;
        var separator = numberFormatInfo.NumberDecimalSeparator == "," || numberFormatInfo.NumberGroupSeparator == ","
            ? ";"
            : ",";
        var xs = x.ToString(format, numberFormatInfo);
        var ys = y.ToString(format, numberFormatInfo);
        var zs = z.ToString(format, numberFormatInfo);
        return $"({xs}{separator}\u00A0{ys}{separator}\u00A0{zs})";
    }


    public override bool Equals(object? obj)
    {
        return obj is BlockPoint3D other && Equals(this, other);
    }

    public bool Equals(BlockPoint3D other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        var a = ((X << 5) + X) ^ Z;
        return ((a << 5) + a) ^ Y;
    }

    public string ToString(IFormatProvider? formatProvider)
    {
        return ToString("D", formatProvider);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString(X, Y, Z, format, formatProvider);
    }
}