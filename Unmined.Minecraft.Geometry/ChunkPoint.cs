using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer chunk point
/// </summary>
[DebuggerStepThrough]
public readonly struct ChunkPoint : IEquatable<ChunkPoint>, IFormattable
{
    public static ChunkPoint Empty = new(0, 0);


    public readonly int X;
    public readonly int Z;

    public ChunkPoint(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Left => X;
    public int Top => Z;

    public static bool operator ==(ChunkPoint left, ChunkPoint right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(ChunkPoint left, ChunkPoint right)
    {
        return !(left == right);
    }

    public static ChunkPoint operator +(ChunkPoint left, ChunkVector right)
    {
        return new ChunkPoint(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator ChunkPoint(ChunkVector chunkVector)
    {
        return new ChunkPoint(chunkVector.X, chunkVector.Z);
    }

    public static explicit operator ChunkPoint(ChunkSize chunkSize)
    {
        return new ChunkPoint(chunkSize.X, chunkSize.Z);
    }

    public static ChunkPoint operator -(ChunkPoint left, ChunkVector right)
    {
        return new ChunkPoint(left.X - right.X, left.Z - right.Z);
    }

    public static ChunkVector operator -(ChunkPoint left, ChunkPoint right)
    {
        return new ChunkVector(left.X - right.X, left.Z - right.Z);
    }

    public static ChunkPoint Create(int x, int z)
    {
        return new ChunkPoint(x, z);
    }

    public static bool Equals(ChunkPoint a, ChunkPoint b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is ChunkPoint other && Equals(this, other);
    }

    public bool Equals(ChunkPoint other)
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
        return 'c' + IntPoint.ToString(X, Z, format, formatProvider);
    }

    public ChunkPoint WithX(int x)
    {
        return new ChunkPoint(x, Z);
    }

    public ChunkPoint WithZ(int z)
    {
        return new ChunkPoint(X, z);
    }
}