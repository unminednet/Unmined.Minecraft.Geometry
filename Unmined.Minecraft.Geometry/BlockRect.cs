using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer block rectangle
/// </summary>
[DebuggerStepThrough]
public readonly struct BlockRect : IEquatable<BlockRect>, IFormattable
{
    public static readonly BlockRect Empty = new(0, 0, 0, 0);

    public readonly int SizeX;
    public readonly int SizeZ;
    public readonly int X;
    public readonly int Z;

    public BlockRect(int x, int z, int sizeX, int sizeZ)
    {
        X = x;
        Z = z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public BlockRect(BlockPoint location, BlockSize size)
    {
        X = location.X;
        Z = location.Z;
        SizeX = size.X;
        SizeZ = size.Z;
    }

    public BlockRect(BlockPoint location, int sizeX, int sizeZ)
    {
        X = location.X;
        Z = location.Z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public BlockPoint BottomLeft => new(X, Z + SizeZ);

    public BlockPoint BottomRight => new(X + SizeX, Z + SizeZ);

    public BlockPoint Center => new(X + SizeX / 2, Z + SizeZ / 2);

    public BlockSize Size => new(SizeX, SizeZ);

    public BlockPoint TopLeft => new(X, Z);

    public BlockPoint TopRight => new(X + SizeX, Z);

    public int Bottom => Z + SizeZ;

    public int Height => SizeZ;

    public bool IsEmpty => Width <= 0 || Height <= 0;

    public int Left => X;

    public int Right => X + SizeX;

    public int Top => Z;

    public int Width => SizeX;

    public static BlockRect operator +(BlockRect left, BlockVector right)
    {
        return new BlockRect(left.TopLeft + right, left.Size);
    }

    public static BlockRect operator -(BlockRect left, BlockVector right)
    {
        return new BlockRect(left.TopLeft - right, left.Size);
    }

    public static bool operator ==(BlockRect left, BlockRect right)
    {
        return
            left.X == right.X
            && left.Z == right.Z
            && left.SizeX == right.SizeX
            && left.SizeZ == right.SizeZ;
    }

    public static bool operator !=(BlockRect left, BlockRect right)
    {
        return !(left == right);
    }

    public static BlockRect BoundsRectOf(IEnumerable<BlockPoint> blocks)
    {
        var result =
            blocks.Aggregate(
                Empty,
                (a, i) => BoundsRectOf(new BlockRect(i, new BlockSize(1, 1)), a));
        return result;
    }

    public static BlockRect BoundsRectOf(BlockRect a, BlockRect b)
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

    public static BlockRect BoundsRectOf(IEnumerable<BlockRect> blockRects)
    {
        return blockRects.Aggregate(Empty, BoundsRectOf);
    }

    public static bool Equals(BlockRect a, BlockRect b)
    {
        return a == b;
    }

    public static BlockRect FromLtrb(int left, int top, int right, int bottom)
    {
        return new BlockRect(left, top, right - left, bottom - top);
    }

    public static BlockRect Intersect(BlockRect a, BlockRect b)
    {
        if (a.IsEmpty || b.IsEmpty)
            return Empty;

        var x1 = Math.Max(a.Left, b.Left);
        var x2 = Math.Min(a.Right, b.Right);
        var y1 = Math.Max(a.Top, b.Top);
        var y2 = Math.Min(a.Bottom, b.Bottom);

        if (x2 >= x1 && y2 >= y1)
            return FromLtrb(x1, y1, x2, y2);

        return Empty;
    }

    public bool Contains(BlockRect rect)
    {
        return
            rect.Left >= Left
            && rect.Top >= Top
            && rect.Right <= Right
            && rect.Bottom <= Bottom;
    }

    public bool Contains(BlockPoint p)
    {
        return
            p.X >= Left
            && p.X < Right
            && p.Z >= Top
            && p.Z < Bottom;
    }

    public override bool Equals(object? obj)
    {
        return obj is BlockRect other && Equals(this, other);
    }

    public bool Equals(BlockRect other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        var a = ((X << 5) + X) ^ Z;
        var b = ((SizeX << 5) + SizeX) ^ SizeZ;
        return ((a << 5) + a) ^ b;
    }

    public BlockRect Inflate(int delta)
    {
        return Inflate(delta, delta);
    }


    public BlockRect Inflate(int deltaX, int deltaZ)
    {
        return new BlockRect(
            X - deltaX,
            Z - deltaZ,
            SizeX + deltaX * 2,
            SizeZ + deltaZ * 2);
    }


    public BlockRect Inflate(BlockSize delta)
    {
        return Inflate(delta.X, delta.Z);
    }

    public bool IntersectsWith(BlockRect rect)
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


    public BlockRect Translate(BlockVector v)
    {
        return new BlockRect(
            X + v.X,
            Z + v.Z,
            SizeX,
            SizeZ);
    }


    public BlockRect Translate(int x, int z)
    {
        return new BlockRect(
            X + x,
            Z + z,
            SizeX,
            SizeZ);
    }
}