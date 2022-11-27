using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer rectangle
/// </summary>
[DebuggerStepThrough]
public readonly struct IntRect : IEquatable<IntRect>
{
    public static readonly IntRect Empty = new(0, 0, 0, 0);

    public readonly int SizeX;
    public readonly int SizeZ;
    public readonly int X;
    public readonly int Z;


    public IntRect(int x, int z, int sizeX, int sizeZ)
    {
        X = x;
        Z = z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public IntRect(IntPoint location, IntSize size)
    {
        X = location.X;
        Z = location.Z;
        SizeX = size.X;
        SizeZ = size.Z;
    }

    public IntRect(IntPoint location, int sizeX, int sizeZ)
    {
        X = location.X;
        Z = location.Z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public IntPoint BottomLeft => new(X, Z + SizeZ);

    public IntPoint BottomRight => new(X + SizeX, Z + SizeZ);

    public IntPoint Center => TopLeft + new IntVector(Width / 2, Height / 2);

    public IntSize Size => new(SizeX, SizeZ);

    public IntPoint TopLeft => new(X, Z);

    public IntPoint TopRight => new(X + SizeX, Z);

    public int Bottom => Z + SizeZ;

    public int Height => Size.Z;

    public bool IsEmpty => Width <= 0 || Height <= 0;


    public int Left => X;

    public int Right => X + SizeX;

    public int Top => Z;

    public int Width => Size.X;

    public static bool operator ==(IntRect left, IntRect right)
    {
        return
            left.X == right.X
            && left.Z == right.Z
            && left.SizeX == right.SizeX
            && left.SizeZ == right.SizeZ;
    }

    public static bool operator !=(IntRect left, IntRect right)
    {
        return !(left == right);
    }

    public static IntRect operator +(IntRect left, IntVector right)
    {
        return new IntRect(left.TopLeft + right, left.Size);
    }

    public static IntRect operator -(IntRect left, IntVector right)
    {
        return new IntRect(left.TopLeft - right, left.Size);
    }

    public static IntRect BoundsRectOf(IEnumerable<IntPoint> points)
    {
        var result =
            points.Aggregate(
                Empty,
                (a, i) => BoundsRectOf(new IntRect(i, new IntSize(1, 1)), a));
        return result;
    }

    public static IntRect BoundsRectOf(IntRect a, IntRect b)
    {
        if (a.IsEmpty && b.IsEmpty) return Empty;
        if (a.IsEmpty) return b;
        if (b.IsEmpty) return a;

        return FromLtrb(
            Math.Min(a.Left, b.Left),
            Math.Min(a.Top, b.Top),
            Math.Max(a.Right, b.Right),
            Math.Max(a.Bottom, b.Bottom));
    }

    public static IntRect BoundsRectOf(IEnumerable<IntRect> rects)
    {
        return rects.Aggregate(Empty, BoundsRectOf);
    }

    public static bool Equals(IntRect a, IntRect b)
    {
        return a == b;
    }

    public static IntRect FromLtrb(int left, int top, int right, int bottom)
    {
        return new IntRect(left, top, right - left, bottom - top);
    }

    public static IntRect Intersect(IntRect a, IntRect b)
    {
        var x1 = Math.Max(a.Left, b.Left);
        var x2 = Math.Min(a.Right, b.Right);
        var y1 = Math.Max(a.Top, b.Top);
        var y2 = Math.Min(a.Bottom, b.Bottom);

        if (x2 >= x1 && y2 >= y1)
            return FromLtrb(x1, y1, x2, y2);

        return Empty;
    }

    public static string ToString(int x, int z, int sizeX, int sizeZ, string? format, IFormatProvider? formatProvider)
    {
        var numberFormatInfo = formatProvider != null
            ? NumberFormatInfo.GetInstance(formatProvider)
            : CultureInfo.InvariantCulture.NumberFormat;
        var separator = numberFormatInfo.NumberDecimalSeparator == "," || numberFormatInfo.NumberGroupSeparator == ","
            ? ";"
            : ",";
        var xs = x.ToString(format, numberFormatInfo);
        var zs = z.ToString(format, numberFormatInfo);
        var sizeXs = sizeX.ToString(format, numberFormatInfo);
        var sizeZs = sizeZ.ToString(format, numberFormatInfo);
        return $"({xs}{separator}\u00A0{zs}{separator}\u00A0{sizeXs}\u00A0x\u00A0{sizeZs})";
    }


    public bool Contains(IntRect rect)
    {
        return
            rect.Left >= Left
            && rect.Top >= Top
            && rect.Right <= Right
            && rect.Bottom <= Bottom;
    }

    public bool Contains(IntPoint p)
    {
        return
            p.X >= Left
            && p.X < Right
            && p.Z >= Top
            && p.Z < Bottom;
    }

    public override bool Equals(object? obj)
    {
        return obj is IntRect other && Equals(this, other);
    }

    public bool Equals(IntRect other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        var a = ((X << 5) + X) ^ Z;
        var b = ((SizeX << 5) + SizeX) ^ SizeZ;
        return ((a << 5) + a) ^ b;
    }

    public IntRect Inflate(int delta)
    {
        return Inflate(delta, delta);
    }

    public IntRect Inflate(int deltaX, int deltaZ)
    {
        return new IntRect(
            X - deltaX,
            Z - deltaZ,
            SizeX + deltaX * 2,
            SizeZ + deltaZ * 2);
    }

    public IntRect Inflate(IntSize delta)
    {
        return Inflate(delta.X, delta.Z);
    }

    public bool IntersectsWith(IntRect rect)
    {
        return
            rect.Left < Right
            && rect.Right > Left
            && rect.Top < Bottom
            && rect.Bottom > Top;
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
        return 'r' + ToString(X, Z, SizeX, SizeZ, format, formatProvider);
    }

    public IntRect Translate(int x, int z)
    {
        return new IntRect(X + x, Z + z, Width, Height);
    }

    public IntRect Translate(IntVector v)
    {
        return Translate(v.X, v.Z);
    }
}