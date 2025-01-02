using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ModOfFantasies.Content.WorldGeneration.UndergroundScavage
{
    public class UndergroundScavage : GenPass
    {
        public UndergroundScavage(string name, float loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Underground Scavage";

            int spawnX = Main.spawnTileX;
            int spawnY = Main.spawnTileY;
            int xpos = spawnX - 300;
            int ypos = spawnY + 100;
            int type = TileID.BlueDungeonBrick;
            int plattype = TileID.Platforms;

            //clear area and add walls
            for (int x = xpos - 8; x <= xpos + 40; x++)
            {
                for (int y = ypos; y <= ypos + 36; y++)
                {
                    Main.tile[x, y].ClearEverything();
                        WorldGen.PlaceWall(x, y, WallID.BlueDungeon);
                }
            }

            //roof floor
            for (int x = -7; x < 46; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 0, type);
            }

            //left side
            WorldGen.PlaceTile(xpos - 8, ypos + 0, type);
            WorldGen.PlaceTile(xpos + 40, ypos + 3, TileID.ClosedDoor);
            for (int y = 4; y < 37; y++)
            {
                WorldGen.PlaceTile(xpos - 8, ypos + y, type);
            }

            //right side
            WorldGen.PlaceTile(xpos + 40, ypos + 0, type);
            WorldGen.PlaceTile(xpos - 8, ypos + 3, TileID.ClosedDoor);
            for (int y = 4; y < 37; y++)
            {
                WorldGen.PlaceTile(xpos + 40, ypos + y, type);
            }

            //second floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 6, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 6, plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 6, type);
            }

            //third floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 12, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 12, plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 12, type);
            }

            //fourth floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 18, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 18, plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 18, type);
            }

            //fifth floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 24, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 24, plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 24, type);
            }

            //sixth floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 30, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 30, plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 30, type);
            }

            //seventh floor
            for (int x = -7; x < 12; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 36, type);
            }
            for (int x = 12; x < 19; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 36,  plattype);
            }
            for (int x = 19; x < 40; x++)
            {
                WorldGen.PlaceTile(xpos + x, ypos + 36, type);
            }

            WorldGen.PlaceTile(xpos + 15, ypos + 5, TileID.Campfire);
            int[] randomItems = { ItemID.HealingPotion, ItemID.IronBar, ItemID.LeadBar, ItemID.GoldBar, ItemID.Apple, ItemID.ManaPotion, ItemID.GoldCoin, ItemID.SilverCoin };
            int chestIndex = WorldGen.PlaceChest(xpos + Main.rand.Next(2, 30), ypos + 35);
            if (chestIndex >= 0)
            {
                Chest chest = Main.chest[chestIndex];
                for (int i = 0; i < 7; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[7] = new Item();
                chest.item[7].SetDefaults(ItemID.GoldenKey);
                chest.item[7].stack = 1;
            }

            int chestIndex2 = WorldGen.PlaceChest(xpos + Main.rand.Next(2, 30), ypos + 23);
            if (chestIndex2 >= 0)
            {
                Chest chest = Main.chest[chestIndex2];
                for (int i = 0; i < 7; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[7] = new Item();
                chest.item[7].SetDefaults(ItemID.GoldAxe);
                chest.item[7].stack = 1;
            }

            int chestIndex3 = WorldGen.PlaceChest(xpos + Main.rand.Next(2, 30), ypos + 17);
            if (chestIndex3 >= 0)
            {
                Chest chest = Main.chest[chestIndex3];
                for (int i = 0; i < 7; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[7] = new Item();
                chest.item[7].SetDefaults(ItemID.SuspiciousLookingEye);
                chest.item[7].stack = Main.rand.Next(1, 5);
            }

            int chestIndex4 = WorldGen.PlaceChest(xpos + Main.rand.Next(2, 30), ypos + 11);
            if (chestIndex4 >= 0)
            {
                Chest chest = Main.chest[chestIndex4];
                for (int i = 0; i < 7; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[7] = new Item();
                chest.item[7].SetDefaults(ItemID.SlimeCrown);
                chest.item[7].stack = Main.rand.Next(1, 5);
            }

            int chestIndex5 = WorldGen.PlaceChest(xpos + Main.rand.Next(2, 30), ypos + 5);
            if (chestIndex5 >= 0)
            {
                Chest chest = Main.chest[chestIndex5];
                for (int i = 0; i < 7; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[7] = new Item();
                chest.item[7].SetDefaults(ItemID.ShadowKey);
                chest.item[7].stack = 1;
            }

            int potposy = -1;
            for (int i = 0; i < 7; i++, potposy += 6)
            {
                for (int j = 0; j < 5; j++)
                {
                    WorldGen.PlacePot(xpos + Main.rand.Next(-5, 38), ypos + potposy);
                }
            }
        }
    }
}