using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer chunk size
/// </summary>
[DebuggerStepThrough]
public readonly struct ChunkSize : IEquatable<ChunkSize>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public ChunkSize(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Width => X;
    public int Height => Z;

    public static bool operator ==(ChunkSize left, ChunkSize right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(ChunkSize left, ChunkSize right)
    {
        return !(left == right);
    }

    public static ChunkSize operator +(ChunkSize left, ChunkVector right)
    {
        return new ChunkSize(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator ChunkSize(ChunkPoint chunkPoint)
    {
        return new ChunkSize(chunkPoint.X, chunkPoint.Z);
    }

    public static implicit operator ChunkSize(ChunkVector chunkVector)
    {
        return new ChunkSize(chunkVector.X, chunkVector.Z);
    }

    public static ChunkSize operator -(ChunkSize left, ChunkVector right)
    {
        return new ChunkSize(left.X - right.X, left.Z - right.Z);
    }

    public static ChunkSize Create(int x, int z)
    {
        return new ChunkSize(x, z);
    }

    public static bool Equals(ChunkSize a, ChunkSize b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is ChunkSize other && Equals(this, other);
    }

    public bool Equals(ChunkSize other)
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
        return 'c' + IntSize.ToString(X, Z, format, formatProvider);
    }
}