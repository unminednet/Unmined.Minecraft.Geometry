using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer block vector
/// </summary>
[DebuggerStepThrough]
public readonly struct BlockVector : IEquatable<BlockVector>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public BlockVector(int x, int z)
    {
        X = x;
        Z = z;
    }

    public static BlockVector operator +(BlockVector left, BlockVector right)
    {
        return new BlockVector(left.X + right.X, left.Z + right.Z);
    }

    public static implicit operator BlockVector(BlockPoint blockPoint)
    {
        return new BlockVector(blockPoint.X, blockPoint.Z);
    }

    public static implicit operator BlockVector(BlockSize blockSize)
    {
        return new BlockVector(blockSize.X, blockSize.Z);
    }

    public static BlockVector operator *(BlockVector left, int right)
    {
        return new BlockVector(
            left.X * right,
            left.Z * right);
    }

    public static BlockVector operator *(int left, BlockVector right)
    {
        return right * left;
    }

    public static BlockVector operator -(BlockVector left, BlockVector right)
    {
        return new BlockVector(left.X - right.X, left.Z - right.Z);
    }

    public static bool operator ==(BlockVector left, BlockVector right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(BlockVector left, BlockVector right)
    {
        return !(left == right);
    }

    public static bool Equals(BlockVector a, BlockVector b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is BlockVector other && Equals(this, other);
    }

    public bool Equals(BlockVector other)
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
        return 'b' + IntPoint.ToString(X, Z, format, formatProvider);
    }
}