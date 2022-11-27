using System.Diagnostics;
using System.Globalization;

namespace Unmined.Minecraft.Geometry;

/// <summary>
///     Immutable integer block size
/// </summary>
[DebuggerStepThrough]
public readonly struct BlockSize : IEquatable<BlockSize>, IFormattable
{
    public readonly int X;
    public readonly int Z;

    public BlockSize(int x, int z)
    {
        X = x;
        Z = z;
    }

    public int Width => X;
    public int Height => Z;

    public static BlockSize operator +(BlockSize left, BlockVector right)
    {
        return new BlockSize(left.X + right.X, left.Z + right.Z);
    }

    public static explicit operator BlockSize(BlockPoint blockPoint)
    {
        return new BlockSize(blockPoint.X, blockPoint.Z);
    }

    public static implicit operator BlockSize(BlockVector blockVector)
    {
        return new BlockSize(blockVector.X, blockVector.Z);
    }

    public static BlockSize operator -(BlockSize left, BlockVector right)
    {
        return new BlockSize(left.X - right.X, left.Z - right.Z);
    }

    public static bool operator ==(BlockSize left, BlockSize right)
    {
        return
            left.X == right.X
            && left.Z == right.Z;
    }

    public static bool operator !=(BlockSize left, BlockSize right)
    {
        return !(left == right);
    }

    public static BlockSize Create(int x, int z)
    {
        return new BlockSize(x, z);
    }

    public static bool Equals(BlockSize a, BlockSize b)
    {
        return a == b;
    }

    public override bool Equals(object? obj)
    {
        return obj is BlockSize other && Equals(this, other);
    }

    public bool Equals(BlockSize other)
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
        return 'b' + IntSize.ToString(X, Z, format, formatProvider);
    }
}