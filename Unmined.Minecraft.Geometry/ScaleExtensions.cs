namespace Unmined.Minecraft.Geometry;

public static class ScaleExtensions
{
    /// <summary>
    ///     Multiplies all coordinates of <paramref name="blockRect" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="blockRect">The <cref>BlockRect</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>BlockRect</cref>.</returns>
    public static BlockRect ScaleBy(this BlockRect blockRect, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? BlockRect.FromLtrb(
                blockRect.Left * factor,
                blockRect.Top * factor,
                blockRect.Right * factor,
                blockRect.Bottom * factor)
            : BlockRect.FromLtrb(
                (int)Math.Floor((double)blockRect.Left / factor),
                (int)Math.Floor((double)blockRect.Top / factor),
                (int)Math.Floor(((double)blockRect.Right - 1) / factor) + 1,
                (int)Math.Floor(((double)blockRect.Bottom - 1) / factor) + 1);
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="chunkRect" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="chunkRect">The <cref>ChunkRect</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>ChunkRect</cref>.</returns>
    public static ChunkRect ScaleBy(this ChunkRect chunkRect, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? ChunkRect.FromLtrb(
                chunkRect.Left * factor,
                chunkRect.Top * factor,
                chunkRect.Right * factor,
                chunkRect.Bottom * factor)
            : ChunkRect.FromLtrb(
                (int)Math.Floor((double)chunkRect.Left / factor),
                (int)Math.Floor((double)chunkRect.Top / factor),
                (int)Math.Floor(((double)chunkRect.Right - 1) / factor) + 1,
                (int)Math.Floor(((double)chunkRect.Bottom - 1) / factor) + 1);
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="regionRect" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="regionRect"><cref>RegionRect</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>RegionRect</cref>.</returns>
    public static RegionRect ScaleBy(this RegionRect regionRect, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? RegionRect.FromLtrb(
                regionRect.Left * factor,
                regionRect.Top * factor,
                regionRect.Right * factor,
                regionRect.Bottom * factor)
            : RegionRect.FromLtrb(
                (int)Math.Floor((double)regionRect.Left / factor),
                (int)Math.Floor((double)regionRect.Top / factor),
                (int)Math.Floor(((double)regionRect.Right - 1) / factor) + 1,
                (int)Math.Floor(((double)regionRect.Bottom - 1) / factor) + 1);
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="intRect" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="intRect"><cref>IntRect</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>IntRect</cref>.</returns>
    public static IntRect ScaleBy(this IntRect intRect, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? IntRect.FromLtrb(
                intRect.Left * factor,
                intRect.Top * factor,
                intRect.Right * factor,
                intRect.Bottom * factor)
            : IntRect.FromLtrb(
                (int)Math.Floor((double)intRect.Left / factor),
                (int)Math.Floor((double)intRect.Top / factor),
                (int)Math.Floor(((double)intRect.Right - 1) / factor) + 1,
                (int)Math.Floor(((double)intRect.Bottom - 1) / factor) + 1);
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="blockPoint" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="blockPoint"><cref>BlockPoint</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>BlockPoint</cref>.</returns>
    public static BlockPoint ScaleBy(this BlockPoint blockPoint, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new BlockPoint(
                blockPoint.X * factor,
                blockPoint.Z * factor)
            : new BlockPoint(
                (int)Math.Floor((double)blockPoint.X / factor),
                (int)Math.Floor((double)blockPoint.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="chunkPoint" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="chunkPoint"><cref>ChunkPoint</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>ChunkPoint</cref>.</returns>
    public static ChunkPoint ScaleBy(this ChunkPoint chunkPoint, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new ChunkPoint(
                chunkPoint.X * factor,
                chunkPoint.Z * factor)
            : new ChunkPoint(
                (int)Math.Floor((double)chunkPoint.X / factor),
                (int)Math.Floor((double)chunkPoint.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="regionPoint" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="regionPoint"><cref>RegionPoint</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>RegionPoint</cref>.</returns>
    public static RegionPoint ScaleBy(this RegionPoint regionPoint, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new RegionPoint(
                regionPoint.X * factor,
                regionPoint.Z * factor)
            : new RegionPoint(
                (int)Math.Floor((double)regionPoint.X / factor),
                (int)Math.Floor((double)regionPoint.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="intPoint" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="intPoint"><cref>IntPoint</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>IntPoint</cref>.</returns>
    public static IntPoint ScaleBy(this IntPoint intPoint, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new IntPoint(
                intPoint.X * factor,
                intPoint.Z * factor)
            : new IntPoint(
                (int)Math.Floor((double)intPoint.X / factor),
                (int)Math.Floor((double)intPoint.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="blockSize" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="blockSize"><cref>BlockSize</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>BlockSize</cref>.</returns>
    public static BlockSize ScaleBy(this BlockSize blockSize, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new BlockSize(
                blockSize.X * factor,
                blockSize.Z * factor)
            : new BlockSize(
                (int)Math.Floor((double)blockSize.X / factor),
                (int)Math.Floor((double)blockSize.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="chunkSize" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="chunkSize"><cref>ChunkSize</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>ChunkSize</cref>.</returns>
    public static ChunkSize ScaleBy(this ChunkSize chunkSize, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new ChunkSize(
                chunkSize.X * factor,
                chunkSize.Z * factor)
            : new ChunkSize(
                (int)Math.Floor((double)chunkSize.X / factor),
                (int)Math.Floor((double)chunkSize.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="regionSize" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="regionSize"><cref>RegionSize</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>RegionSize</cref>.</returns>
    public static RegionSize ScaleBy(this RegionSize regionSize, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new RegionSize(
                regionSize.X * factor,
                regionSize.Z * factor)
            : new RegionSize(
                (int)Math.Floor((double)regionSize.X / factor),
                (int)Math.Floor((double)regionSize.Z / factor));
    }

    /// <summary>
    ///     Multiplies all coordinates of <paramref name="intSize" /> by Math.Pow(2, <paramref name="level" />).
    /// </summary>
    /// <param name="intSize"><cref>IntSize</cref> to scale.</param>
    /// <param name="level">The scale level.</param>
    /// <returns>The scaled <cref>IntSize</cref>.</returns>
    public static IntSize ScaleBy(this IntSize intSize, int level)
    {
        var factor = 1 << Math.Abs(level);

        return level >= 0
            ? new IntSize(
                intSize.X * factor,
                intSize.Z * factor)
            : new IntSize(
                (int)Math.Floor((double)intSize.X / factor),
                (int)Math.Floor((double)intSize.Z / factor));
    }
}