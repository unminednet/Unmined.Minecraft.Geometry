using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer chunk rectangle
/// </summary>
[DebuggerStepThrough]
public readonly struct ChunkRect : IEquatable<ChunkRect>, IFormattable
{
    public static readonly ChunkRect Empty = new(0, 0, 0, 0);

    public readonly int SizeX;
    public readonly int SizeZ;
    public readonly int X;
    public readonly int Z;


    public ChunkRect(int x, int z, int sizeX, int sizeZ)
    {
        X = x;
        Z = z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public ChunkRect(ChunkPoint location, ChunkSize size)
    {
        X = location.X;
        Z = location.Z;
        SizeX = size.X;
        SizeZ = size.Z;
    }

    public ChunkRect(ChunkPoint location, int sizeX, int sizeZ)
    {
        X = location.X;
        Z = location.Z;
        SizeX = sizeX;
        SizeZ = sizeZ;
    }

    public ChunkPoint BottomLeft => new(X, Z + SizeZ);

    public ChunkPoint BottomRight => new(X + SizeX, Z + SizeZ);

    public ChunkPoint Center => new(X + SizeX / 2, Z + SizeZ / 2);

    public ChunkSize Size => new(SizeX, SizeZ);

    public ChunkPoint TopLeft => new(X, Z);

    public ChunkPoint TopRight => new(X + SizeX, Z);

    public bool IsEmpty => Width <= 0 || Height <= 0;

    public int Bottom => Z + SizeZ;

    public int Height => SizeZ;

    public int Left => X;

    public int Right => X + SizeX;

    public int Top => Z;

    public int Width => SizeX;

    public static bool operator ==(ChunkRect left, ChunkRect right)
    {
        return
            left.X == right.X
            && left.Z == right.Z
            && left.SizeX == right.SizeX
            && left.SizeZ == right.SizeZ;
    }

    public static bool operator !=(ChunkRect left, ChunkRect right)
    {
        return !(left == right);
    }

    public static ChunkRect operator +(ChunkRect left, ChunkVector right)
    {
        return new ChunkRect(left.TopLeft + right, left.Size);
    }

    public static ChunkRect operator -(ChunkRect left, ChunkVector right)
    {
        return new ChunkRect(left.TopLeft - right, left.Size);
    }

    public static ChunkRect BoundsRectOf(IEnumerable<ChunkPoint> chunks)
    {
        var result =
            chunks.Aggregate(
                Empty,
                (a, i) => BoundsRectOf(new ChunkRect(i, new ChunkSize(1, 1)), a));
        return result;
    }

    public static ChunkRect BoundsRectOf(ChunkRect a, ChunkRect b)
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

    public static ChunkRect BoundsRectOf(IEnumerable<ChunkRect> chunkRects)
    {
        return chunkRects.Aggregate(Empty, BoundsRectOf);
    }

    public static bool Equals(ChunkRect a, ChunkRect b)
    {
        return a == b;
    }

    public static ChunkRect FromLtrb(int left, int top, int right, int bottom)
    {
        return new ChunkRect(left, top, right - left, bottom - top);
    }

    public static ChunkRect Intersect(ChunkRect a, ChunkRect b)
    {
        var x1 = Math.Max(a.Left, b.Left);
        var x2 = Math.Min(a.Right, b.Right);
        var y1 = Math.Max(a.Top, b.Top);
        var y2 = Math.Min(a.Bottom, b.Bottom);

        if (x2 >= x1 && y2 >= y1)
            return FromLtrb(x1, y1, x2, y2);

        return Empty;
    }


    public bool Contains(ChunkRect rect)
    {
        return
            rect.Left >= Left
            && rect.Top >= Top
            && rect.Right <= Right
            && rect.Bottom <= Bottom;
    }


    public bool Contains(ChunkPoint p)
    {
        return
            p.X >= Left
            && p.X < Right
            && p.Z >= Top
            && p.Z < Bottom;
    }

    public override bool Equals(object? obj)
    {
        return obj is ChunkRect other && Equals(this, other);
    }

    public bool Equals(ChunkRect other)
    {
        return Equals(this, other);
    }

    public override int GetHashCode()
    {
        var a = ((X << 5) + X) ^ Z;
        var b = ((SizeX << 5) + SizeX) ^ SizeZ;
        return ((a << 5) + a) ^ b;
    }

    public ChunkRect Inflate(int delta)
    {
        return Inflate(delta, delta);
    }


    public ChunkRect Inflate(int deltaX, int deltaZ)
    {
        return new ChunkRect(
            X - deltaX,
            Z - deltaZ,
            SizeX + deltaX * 2,
            SizeZ + deltaZ * 2);
    }


    public ChunkRect Inflate(ChunkSize delta)
    {
        return Inflate(delta.X, delta.Z);
    }

    public bool IntersectsWith(ChunkRect rect)
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


    public ChunkRect Translate(ChunkVector v)
    {
        return new ChunkRect(
            X + v.X,
            Z + v.Z,
            SizeX,
            SizeZ);
    }


    public ChunkRect Translate(int x, int z)
    {
        return new ChunkRect(
            X + x,
            Z + z,
            SizeX,
            SizeZ);
    }
}