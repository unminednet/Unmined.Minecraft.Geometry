namespace Unmined.Minecraft.Geometry;

public static class Units
{
    public const int BlocksPerChunk = 16;
    public const int BlocksPerSection = 16;
    public const int ChunksPerRegion = 32;
    public const int BlocksPerRegion = ChunksPerRegion * BlocksPerChunk;

    public static int GetMaxBlockYOfSection(int section)
    {
        return (section + 1) * BlocksPerSection - 1;
    }

    public static int GetMinBlockYOfSection(int section)
    {
        return section * BlocksPerSection;
    }

    public static int GetSection(int blockY)
    {
        return blockY < 0
            ? (blockY - BlocksPerSection + 1) / BlocksPerSection
            : blockY / BlocksPerSection;
    }

    public static int GetSectionRelativeBlockY(int blockY)
    {
        return blockY < 0
            ? (blockY % BlocksPerSection + BlocksPerSection) % BlocksPerSection
            : blockY % BlocksPerSection;
    }
}