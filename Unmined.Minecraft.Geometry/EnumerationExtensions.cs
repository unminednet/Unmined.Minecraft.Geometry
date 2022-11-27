namespace Unmined.Minecraft.Geometry;

public static class EnumerationExtensions
{
    public static IEnumerable<BlockPoint> EnumBlocksZx(this BlockRect r)
    {
        for (var z = r.Top; z < r.Bottom; z++)
        for (var x = r.Left; x < r.Right; x++)
            yield return new BlockPoint(x, z);
    }

    public static IEnumerable<ChunkPoint> EnumChunksZx(this ChunkRect r)
    {
        for (var z = r.Top; z < r.Bottom; z++)
        for (var x = r.Left; x < r.Right; x++)
            yield return new ChunkPoint(x, z);
    }

    public static IEnumerable<IntPoint> EnumIntPointsZx(this IntRect r)
    {
        for (var z = r.Top; z < r.Bottom; z++)
        for (var x = r.Left; x < r.Right; x++)
            yield return new IntPoint(x, z);
    }

    public static IEnumerable<RegionPoint> EnumRegionsZx(this RegionRect r)
    {
        for (var z = r.Top; z < r.Bottom; z++)
        for (var x = r.Left; x < r.Right; x++)
            yield return new RegionPoint(x, z);
    }
}