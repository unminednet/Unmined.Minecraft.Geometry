namespace Unmined.Minecraft.Geometry;

public static class ConversionExtensions
{
    public static BlockPoint ToBlockPoint(this WorldPoint3D worldPoint3D)
    {
        return
            new BlockPoint(
                (int)Math.Floor(worldPoint3D.X),
                (int)Math.Floor(worldPoint3D.Z));
    }

    public static BlockPoint ToBlockPoint(this BlockPoint3D point3D)
    {
        return
            new BlockPoint(
                point3D.X,
                point3D.Z);
    }

    public static BlockRect ToBlockRect(this ChunkPoint chunkPoint)
    {
        return new BlockRect(
            chunkPoint.X * Units.BlocksPerChunk,
            chunkPoint.Z * Units.BlocksPerChunk,
            Units.BlocksPerChunk,
            Units.BlocksPerChunk);
    }

    public static BlockRect ToBlockRect(this ChunkRect chunkRect)
    {
        return new BlockRect(
            chunkRect.X * Units.BlocksPerChunk,
            chunkRect.Z * Units.BlocksPerChunk,
            chunkRect.SizeX * Units.BlocksPerChunk,
            chunkRect.SizeZ * Units.BlocksPerChunk);
    }

    public static BlockRect ToBlockRect(this IntPoint tilePoint, int tileSize)
    {
        return new BlockRect(
            tilePoint.X * tileSize,
            tilePoint.Z * tileSize,
            tileSize,
            tileSize);
    }

    public static BlockRect ToBlockRect(this IntRect tileRect, int tileSize)
    {
        return new BlockRect(
            tileRect.X * tileSize,
            tileRect.Z * tileSize,
            tileRect.Width * tileSize,
            tileRect.Height * tileSize);
    }

    public static BlockRect ToBlockRect(this RegionPoint regionPoint)
    {
        return new BlockRect(
            regionPoint.X * Units.BlocksPerRegion,
            regionPoint.Z * Units.BlocksPerRegion,
            Units.BlocksPerRegion,
            Units.BlocksPerRegion);
    }

    public static BlockRect ToBlockRect(this RegionRect regionRect)
    {
        return new BlockRect(
            regionRect.X * Units.BlocksPerRegion,
            regionRect.Z * Units.BlocksPerRegion,
            regionRect.SizeX * Units.BlocksPerRegion,
            regionRect.SizeZ * Units.BlocksPerRegion);
    }

    public static BlockRect ToBlockRect(this BlockPoint blockPoint)
    {
        return new BlockRect(blockPoint, new BlockSize(1, 1));
    }

    public static ChunkPoint ToChunkPoint(this BlockPoint blockPoint)
    {
        return new ChunkPoint(
            (int)Math.Floor((double)blockPoint.X / Units.BlocksPerChunk),
            (int)Math.Floor((double)blockPoint.Z / Units.BlocksPerChunk));
    }

    /// <summary>
    ///     Returns the smallest <See cref="ChunkRect" /> that contains the entire <paramref name="blockRect" />.
    /// </summary>
    /// <param name="blockRect"></param>
    /// <returns></returns>
    public static ChunkRect ToChunkRect(this BlockRect blockRect)
    {
        return ChunkRect.FromLtrb(
            (int)Math.Floor((double)blockRect.Left / Units.BlocksPerChunk),
            (int)Math.Floor((double)blockRect.Top / Units.BlocksPerChunk),
            (int)Math.Floor(((double)blockRect.Right - 1) / Units.BlocksPerChunk) + 1,
            (int)Math.Floor(((double)blockRect.Bottom - 1) / Units.BlocksPerChunk) + 1);
    }

    public static ChunkRect ToChunkRect(this RegionPoint regionPoint)
    {
        return new ChunkRect(
            regionPoint.X * Units.ChunksPerRegion,
            regionPoint.Z * Units.ChunksPerRegion,
            Units.ChunksPerRegion,
            Units.ChunksPerRegion);
    }

    public static ChunkRect ToChunkRect(this RegionRect regionRect)
    {
        return new ChunkRect(
            regionRect.X * Units.ChunksPerRegion,
            regionRect.Z * Units.ChunksPerRegion,
            regionRect.SizeX * Units.ChunksPerRegion,
            regionRect.SizeZ * Units.ChunksPerRegion);
    }

    public static ChunkRect ToChunkRect(this ChunkPoint chunkPoint)
    {
        return new ChunkRect(chunkPoint, new ChunkSize(1, 1));
    }

    public static BlockPoint ToChunkRelative(this BlockPoint blockPoint)
    {
        var c = blockPoint.ToChunkPoint().ToBlockRect().TopLeft;
        return new BlockPoint(blockPoint.X - c.X, blockPoint.Z - c.Z);
    }

    public static RegionPoint ToRegionPoint(this BlockPoint blockPoint)
    {
        return new RegionPoint(
            (int)Math.Floor((double)blockPoint.X / Units.BlocksPerRegion),
            (int)Math.Floor((double)blockPoint.Z / Units.BlocksPerRegion));
    }

    public static RegionPoint ToRegionPoint(this ChunkPoint chunkPoint)
    {
        return
            new RegionPoint(
                (int)Math.Floor((double)chunkPoint.X / Units.ChunksPerRegion),
                (int)Math.Floor((double)chunkPoint.Z / Units.ChunksPerRegion));
    }

    public static RegionRect ToRegionRect(this RegionPoint regionPoint)
    {
        return new RegionRect(regionPoint, new RegionSize(1, 1));
    }

    /// <summary>
    ///     Returns the smallest <See cref="RegionRect" /> that contains the entire <paramref name="blockRect" />.
    /// </summary>
    /// <param name="blockRect"></param>
    /// <returns></returns>
    public static RegionRect ToRegionRect(this BlockRect blockRect)
    {
        return RegionRect.FromLtrb(
            (int)Math.Floor((double)blockRect.Left / Units.BlocksPerRegion),
            (int)Math.Floor((double)blockRect.Top / Units.BlocksPerRegion),
            (int)Math.Floor(((double)blockRect.Right - 1) / Units.BlocksPerRegion) + 1,
            (int)Math.Floor(((double)blockRect.Bottom - 1) / Units.BlocksPerRegion) + 1);
    }

    /// <summary>
    ///     Returns the smallest <See cref="RegionRect" /> that contains the entire <paramref name="chunkRect" />.
    /// </summary>
    /// <param name="chunkRect"></param>
    /// <returns></returns>
    public static RegionRect ToRegionRect(this ChunkRect chunkRect)
    {
        return RegionRect.FromLtrb(
            (int)Math.Floor((double)chunkRect.Left / Units.ChunksPerRegion),
            (int)Math.Floor((double)chunkRect.Top / Units.ChunksPerRegion),
            (int)Math.Floor(((double)chunkRect.Right - 1) / Units.ChunksPerRegion) + 1,
            (int)Math.Floor(((double)chunkRect.Bottom - 1) / Units.ChunksPerRegion) + 1);
    }

    public static BlockPoint ToRegionRelative(this BlockPoint blockPoint)
    {
        var c = blockPoint.ToRegionPoint().ToBlockRect().TopLeft;
        return new BlockPoint(blockPoint.X - c.X, blockPoint.Z - c.Z);
    }

    public static ChunkPoint ToRegionRelative(this ChunkPoint chunkPoint)
    {
        var c = chunkPoint.ToRegionPoint().ToChunkRect().TopLeft;
        return new ChunkPoint(chunkPoint.X - c.X, chunkPoint.Z - c.Z);
    }


    public static IntPoint ToTilePoint(this BlockPoint blockPoint, int tileSize)
    {
        return new IntPoint(
            (int)Math.Floor((double)blockPoint.X / tileSize),
            (int)Math.Floor((double)blockPoint.Z / tileSize));
    }

    public static IntRect ToTileRect(this BlockRect blockRect, int tileSize)
    {
        return IntRect.FromLtrb(
            (int)Math.Floor((double)blockRect.Left / tileSize),
            (int)Math.Floor((double)blockRect.Top / tileSize),
            (int)Math.Floor(((double)blockRect.Right - 1) / tileSize) + 1,
            (int)Math.Floor(((double)blockRect.Bottom - 1) / tileSize) + 1);
    }

    public static BlockPoint ToTileRelative(this BlockPoint blockPoint, int tileSize)
    {
        var c = blockPoint.ToTilePoint(tileSize).ToBlockRect(tileSize).TopLeft;
        return new BlockPoint(blockPoint.X - c.X, blockPoint.Z - c.Z);
    }

    public static ChunkPoint ToTileRelative(this ChunkPoint chunkPoint, int tileSize)
    {
        var topLeft = chunkPoint.ToBlockRect().TopLeft.ToTilePoint(tileSize).ToBlockRect(tileSize).ToChunkRect();
        return new ChunkPoint(chunkPoint.X - topLeft.X, chunkPoint.Z - topLeft.Z);
    }

    public static RegionPoint ToTileRelative(this RegionPoint regionPoint, int tileSize)
    {
        var topLeft = regionPoint.ToBlockRect().TopLeft.ToTilePoint(tileSize).ToBlockRect(tileSize).ToRegionRect();
        return new RegionPoint(regionPoint.X - topLeft.X, regionPoint.Z - topLeft.Z);
    }

    public static BlockRect ToTileRelative(this BlockRect blockRect, int tileSize)
    {
        return new BlockRect(blockRect.TopLeft.ToTileRelative(tileSize), blockRect.Size);
    }

    public static ChunkRect ToTileRelative(this ChunkRect chunkRect, int tileSize)
    {
        return new ChunkRect(chunkRect.TopLeft.ToTileRelative(tileSize), chunkRect.Size);
    }

    public static RegionRect ToTileRelative(this RegionRect regionRect, int tileSize)
    {
        return new RegionRect(regionRect.TopLeft.ToTileRelative(tileSize), regionRect.Size);
    }
}