using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer block point
/// </summary>
[DebuggerStepThrough]
public readonly struct BlockPoint : IEquatable<BlockPoint>, IFormattable
{
    public static BlockPoint Empty = new(0, 0);

    public readonly int X;
    public readonly int Z;

    public BlockPoint(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Left => X;
    public int Top => Z;

    public static BlockPoint operator +(BlockPoint left, BlockVector right)
    {
        return new BlockPoint(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator BlockPoint(BlockSize blockSize)
    {
        return new BlockPoint(blockSize.X, blockSize.Z);
    }

    public static explicit operator BlockPoint(BlockVector blockVector)
    {
        return new BlockPoint(blockVector.X, blockVector.Z);
    }

    public static BlockPoint operator -(BlockPoint left, BlockVector right)
    {
        return new BlockPoint(left.X - right.X, left.Z - right.Z);
    }

    public static BlockVector operator -(BlockPoint left, BlockPoint right)
    {
        return new BlockVector(left.X - right.X, left.Z - right.Z);
    }

    public static bool operator ==(BlockPoint left, BlockPoint right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(BlockPoint left, BlockPoint right)
    {
        return !(left == right);
    }

    public static BlockPoint Create(int x, int z)
    {
        return new BlockPoint(x, z);
    }

    public static bool Equals(BlockPoint a, BlockPoint b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is BlockPoint other && Equals(this, other);
    }

    public bool Equals(BlockPoint other)
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
        return 'b' + IntPoint.ToString(X, Z, format, formatProvider);
    }

    public BlockPoint WithX(int x)
    {
        return new BlockPoint(x, Z);
    }

    public BlockPoint WithZ(int z)
    {
        return new BlockPoint(X, z);
    }
}