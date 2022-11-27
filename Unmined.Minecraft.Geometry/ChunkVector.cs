using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer chunk vector
/// </summary>
[DebuggerStepThrough]
public readonly struct ChunkVector : IEquatable<ChunkVector>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public ChunkVector(int x, int z)
    {
        X = x;
        Z = z;
    }

    public static bool operator ==(ChunkVector left, ChunkVector right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(ChunkVector left, ChunkVector right)
    {
        return !(left == right);
    }

    public static ChunkVector operator +(ChunkVector left, ChunkVector right)
    {
        return new ChunkVector(left.X + right.X, left.Z + right.Z);
    }

    public static implicit operator ChunkVector(ChunkPoint chunkPoint)
    {
        return new ChunkVector(chunkPoint.X, chunkPoint.Z);
    }

    public static implicit operator ChunkVector(ChunkSize chunkSize)
    {
        return new ChunkVector(chunkSize.X, chunkSize.Z);
    }

    public static ChunkVector operator -(ChunkVector left, ChunkVector right)
    {
        return new ChunkVector(left.X - right.X, left.Z - right.Z);
    }

    public static bool Equals(ChunkVector a, ChunkVector b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is ChunkVector other && Equals(this, other);
    }

    public bool Equals(ChunkVector other)
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
        return 'c' + IntPoint.ToString(X, Z, format, formatProvider);
    }
}