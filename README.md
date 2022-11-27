# uNmINeD.NET Geometry Library

![Build status](https://github.com/unminednet/unmined.minecraft.geometry/actions/workflows/publish.yml/badge.svg)

## Introduction

The uNmINeD.NET Geometry Library provides immutable C# types to work with block, chunk and region coordinate systems used in Minecraft.
It is designed to make geometry related code more readable and less likely to contain mistakes.

## Features

__Axes__ are the same as in Minecraft:

* X: negative is west, positive is east (left and right on maps)
* Z: negative is is north, positive is south (top and bottom on maps)
* Y: negative is down, positive is up

There are distinct two-dimensional (X-Z plane) integer __readonly struct__ types for each unit of measure (__Block__, __Chunk__, __Region__ and general __Int__), like BlockPoint or ChunkRect: 

```csharp
// 32x32 area at x=16,z=0
var br = new BlockRect(x: 20, z: 0, width: 32, height: 32));

Console.WriteLine(br); // b(20, 0, 32 x 32)
Console.WriteLine(br.Top); // "0", inside the rectangle
Console.WriteLine(br.Bottom); // "32", outside the rectangle
Console.WriteLine(br.Height); // "32", Top + Height = Bottom

Console.WriteLine(br.Contains(br.TopLeft)); // "true", TopLeft is inside the rectangle
Console.WriteLine(br.Contains(br.BottomRight)); // "false", BottomRight is outside the rectangle
Console.WriteLine(br.Contains(new BlockPoint(20, 0))); // "true"
Console.WriteLine(br.Contains(new BlockPoint(20, 31))); // "true"
Console.WriteLine(br.Contains(new BlockPoint(20, 32))); // "false"

Console.WriteLine(br.Contains(new ChunkPoint(2, 0))); // !!! compiler error
Console.WriteLine(br.Contains(new ChunkPoint(2, 0).ToBlockRect())); // "true"
Console.WriteLine(br.Contains(new ChunkPoint(1, 0).ToBlockRect())); // "false"
Console.WriteLine(br.IntersectsWith(new ChunkPoint(1, 0).ToBlockRect())); // "true"
```

__Conversions__:

```csharp
Console.WriteLine(new BlockPoint(20, 25).ToRegionPoint().ToChunkRect()); // "c(0, 0, 32 x 32)"
Console.WriteLine(GetTopLeftBlockOfContainingChunk(new BlockPoint(20, 25))); // "b(16, 16)"

public BlockPoint GetTopLeftBlockOfContainingChunk(BlockPoint blockPoint)
{
    return blockPoint    // b(20, 25)
        .ToChunkPoint()  // c(1, 1)
        .ToBlockRect()   // b(16, 16, 16 x 16)
        .TopLeft;        // b(16, 16)
}
```

__Constants__:

```csharp
var sectionBlockBuffer3D = 
    new Block[
        Units.BlocksPerChunk        // 16
        * Units.BlocksPerChunk      // 16
        * Units.BlocksPerSection];  // 16
```

__Chunk section__ math:

```csharp
Console.WriteLine(Units.GetSectionY(blockY: -16)); // -1
Console.WriteLine(Units.GetSectionY(blockY: -17)); // -2
```

__Tile__ math:

```csharp
var tileSize = 256;
IntPoint tilePoint = new BlockPoint(10, 300).ToTilePoint(tileSize); // (0, 1)
BlockRect tileBlockRect = tilePoint.ToBlockRect(tileSize); // b(0, 0, 256 x 256)
```

__Integer scaling__ by Math.Pow(2, n):

```csharp
Console.WriteLine(new BlockPoint(20, 20).ScaleBy(1)); // "b(40, 40)"
Console.WriteLine(new BlockPoint(20, 20).ScaleBy(-2)); // "b(5, 5)"
```

All structs are __IEquatable&lt;T&gt;__ and can be used as dictionary keys:

```csharp
var loadedChunks = new Dictionary<ChunkPoint, IChunk>();
```

## Usage

Add `https://nuget.pkg.github.com/unminednet/index.json` to NuGet sources, then add the `Unmined.Minecraft.Geometry` NuGet package to csproj:

```xml
<ItemGroup>
    <PackageReference Include="Unmined.Minecraft.Geometry" Version="0.1.1" />
</ItemGroup>
```

## Build

```shell
git checkout https://github.com/unminednet/Unmined.Minecraft.Geometry.git
dotnet build
```

## Credits

The uNmINeD.NET Geometry Library was created by Balázs Farkas (megasys).

## License

The uNmINeD.NET Geometry Library is released under the MIT license.

## Contributing and support

You can support the author on [Patreon](https://www.patreon.com/megasys).

You can also contribute to the project by reporting a bug or improving the code. Please always open an issue before starting to work on a pull request.

## Legal notes

The uNmINeD.NET Geometry Library is not an official Minecraft product, and is not approved by or associated with Mojang.
