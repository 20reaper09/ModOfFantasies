using ModOfFantasies.Content.WorldGeneration.UndergroundScavage;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TrashMod.Content.WorldGeneration
{
    public class WorldPasses : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int PubPass = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (PubPass != -1)
            {
                tasks.Insert(PubPass + 1, new Pub("Pub Gen", 237.4298f));
            }

            int ScavagePass = tasks.FindIndex(genPass => genPass.Name.Equals("Final Cleanup"));
            if (ScavagePass != -1)
            {
                tasks.Insert(ScavagePass + 1, new UndergroundScavage("Scavage Gen", 237.4298f));
            }
        }

    }
}