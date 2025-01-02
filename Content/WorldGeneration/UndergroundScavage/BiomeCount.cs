using ModOfFantasies.Content.Items.Placeable;
using System;
using Terraria.ModLoader;

namespace ModOfFantasies.Content.WorldGeneration.UndergroundScavage
{
    public class BiomeCount : ModSystem
    {
        public int count;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            count = tileCounts[ModContent.TileType<CrystaStone>()];
        }
    }
}