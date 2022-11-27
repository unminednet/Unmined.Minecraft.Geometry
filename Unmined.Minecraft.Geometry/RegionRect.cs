using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer region rectangle
/// </summary>
[DebuggerStepThrough]
public readonly struct RegionRect : IEquatable<RegionRect>, IFormattable
{
    public static readonly RegionRect Empty = new(0, 0, 0, 0);

    public readonly int SizeX;
    public readonly int SizeZ;
    public readonly int X;
    public readonly int Z;

    public RegionRect(int x, int z, int sizeX, int sizeZ)
    {
        X = x;
        Z = z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }


    public RegionRect(RegionPoint location, RegionSize size)
    {
        X = location.X;
        Z = location.Z;
        SizeX = size.X;
        SizeZ = size.Z;
    }

    public RegionRect(RegionPoint location, int sizeX, int sizeZ)
    {
        X = location.X;
        Z = location.Z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public RegionPoint BottomLeft => new(X, Z + SizeZ);

    public RegionPoint BottomRight => new(X + SizeX, Z + SizeZ);

    public RegionPoint Center => new(X + SizeX / 2, Z + SizeZ / 2);

    public RegionSize Size => new(SizeX, SizeZ);

    public RegionPoint TopLeft => new(X, Z);


    public RegionPoint TopRight => new(X + SizeX, Z);

    public int Bottom => Z + SizeZ;

    public int Height => SizeZ;

    public bool IsEmpty => Width <= 0 || Height <= 0;

    public int Left => X;

    public int Right => X + SizeX;

    public int Top => Z;

    public int Width => SizeX;

    public static bool operator ==(RegionRect left, RegionRect right)
    {
        return
            left.X == right.X
            && left.Z == right.Z
            && left.SizeX == right.SizeX
            && left.SizeZ == right.SizeZ;
    }

    public static bool operator !=(RegionRect left, RegionRect right)
    {
        return !(left == right);
    }

    public static RegionRect operator +(RegionRect left, RegionVector right)
    {
        return new RegionRect(left.TopLeft + right, left.Size);
    }

    public static RegionRect operator -(RegionRect left, RegionVector right)
    {
        return new RegionRect(left.TopLeft - right, left.Size);
    }

    public static RegionRect BoundsRectOf(IEnumerable<RegionPoint> regions)
    {
        var result =
            regions.Aggregate(
                Empty,
                (a, i) => BoundsRectOf(new RegionRect(i, new RegionSize(1, 1)), a));
        return result;
    }

    public static RegionRect BoundsRectOf(RegionRect a, RegionRect b)
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

    public static RegionRect BoundsRectOf(IEnumerable<RegionRect> regionRects)
    {
        return regionRects.Aggregate(Empty, BoundsRectOf);
    }


    public static bool Equals(RegionRect a, RegionRect b)
    {
        return a == b;
    }

    public static RegionRect FromLtrb(int left, int top, int right, int bottom)
    {
        return new RegionRect(left, top, right - left, bottom - top);
    }

    public static RegionRect Intersect(RegionRect a, RegionRect b)
    {
        var x1 = Math.Max(a.Left, b.Left);
        var x2 = Math.Min(a.Right, b.Right);
        var y1 = Math.Max(a.Top, b.Top);
        var y2 = Math.Min(a.Bottom, b.Bottom);

        if (x2 >= x1 && y2 >= y1)
            return FromLtrb(x1, y1, x2, y2);

        return Empty;
    }

    public bool Contains(RegionRect rect)
    {
        return
            rect.Left >= Left
            && rect.Top >= Top
            && rect.Right <= Right
            && rect.Bottom <= Bottom;
    }

    public bool Contains(RegionPoint p)
    {
        return
            p.X >= Left
            && p.X < Right
            && p.Z >= Top
            && p.Z < Bottom;
    }

    public override bool Equals(object? obj)
    {
        return obj is RegionRect other && Equals(this, other);
    }

    public bool Equals(RegionRect other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        var a = ((X << 5) + X) ^ Z;
        var b = ((SizeX << 5) + SizeX) ^ SizeZ;
        return ((a << 5) + a) ^ b;
    }

    public RegionRect Inflate(int delta)
    {
        return Inflate(delta, delta);
    }

    public RegionRect Inflate(int deltaX, int deltaZ)
    {
        return new RegionRect(
            X - deltaX,
            Z - deltaZ,
            SizeX + deltaX * 2,
            SizeZ + deltaZ * 2);
    }

    public RegionRect Inflate(RegionSize delta)
    {
        return Inflate(delta.X, delta.Z);
    }

    public bool IntersectsWith(RegionRect rect)
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
        return 'r' + IntRect.ToString(X, Z, SizeX, SizeZ, format, formatProvider);
    }

    public RegionRect Translate(int x, int z)
    {
        return new RegionRect(X + x, Z + z, Width, Height);
    }

    public RegionRect Translate(RegionVector v)
    {
        return Translate(v.X, v.Z);
    }
}