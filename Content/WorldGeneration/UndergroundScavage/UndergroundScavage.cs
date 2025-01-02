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
            ScavageGen(WorldGen.genRand.Next(400, 600), WorldGen.genRand.Next(175, 250));
            ScavageGen(WorldGen.genRand.Next(-600, -400), WorldGen.genRand.Next(175, 250));
            ScavageGen(WorldGen.genRand.Next(700, 900), WorldGen.genRand.Next(300, 350));
            ScavageGen(WorldGen.genRand.Next(-900, -700), WorldGen.genRand.Next(300, 350));
            ScavageGen(WorldGen.genRand.Next(950, 1050), WorldGen.genRand.Next(400, 450));
            ScavageGen(WorldGen.genRand.Next(-1050, -950), WorldGen.genRand.Next(400, 450));
        }
        private void ScavageGen(int xv, int yv)
        {
            int spawnX = Main.spawnTileX;
            int spawnY = Main.spawnTileY;
            int xpos = spawnX + xv;
            int ypos = spawnY + yv;
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
            for (int y = 4; y < 37; y++)
            {
                WorldGen.PlaceTile(xpos - 8, ypos + y, type);
            }
            WorldGen.PlaceTile(xpos - 8, ypos + 3, TileID.ClosedDoor);

            //right side
            WorldGen.PlaceTile(xpos + 40, ypos + 0, type);
            for (int y = 4; y < 37; y++)
            {
                WorldGen.PlaceTile(xpos + 40, ypos + y, type);
            }
            WorldGen.PlaceTile(xpos + 40, ypos + 3, TileID.ClosedDoor);

            //place every floor
            PlaceFloors(xpos, ypos, type, plattype);

            //campfire
            WorldGen.PlaceTile(xpos + 15, ypos + 5, TileID.Campfire);

            //chests
            PlaceChest(ItemID.GoldenKey, xpos + Main.rand.Next(2, 30), ypos + 35);
            PlaceChest(ItemID.GoldAxe, xpos + Main.rand.Next(2, 30), ypos + 23, Main.rand.Next(1, 11));
            PlaceChest(ItemID.SuspiciousLookingEye, xpos + Main.rand.Next(2, 30), ypos + 17, Main.rand.Next(1, 11));
            PlaceChest(ItemID.SlimeCrown, xpos + Main.rand.Next(2, 30), ypos + 11, Main.rand.Next(1, 11));
            PlaceChest(ItemID.ShadowKey, xpos + Main.rand.Next(2, 30), ypos + 5);

            //pots
            int potposy = -1;
            for (int i = 0; i < 7; i++, potposy += 6)
            {
                for (int j = 0; j < 5; j++)
                {
                    WorldGen.PlacePot(xpos + WorldGen.genRand.Next(-5, 38), ypos + potposy);
                }
            }

            //cobwebs
            for (int x = xpos - 8; x <= xpos + 40; x++)
            {
                for (int y = ypos; y <= ypos + 36; y++)
                {
                    if (WorldGen.genRand.NextFloat() < 0.1f)
                    {
                        if (Main.tile[x, y].HasTile == false) 
                        {
                            WorldGen.PlaceTile(x, y, TileID.Cobweb); 
                        }
                    }
                }
            }

        }

        private void PlaceFloors(int xpos, int ypos, int type, int plattype)
        {
            //loop generates 7 floors
            for (int i = 0; i < 7; i++)
            {
                int floorLevel = i * 6;
                for (int x = -7; x < 40; x++)
                {
                    if (x < 12 || x >= 19)
                    {
                        WorldGen.PlaceTile(xpos + x, ypos + floorLevel, type);
                    }
                    else
                    {
                        WorldGen.PlaceTile(xpos + x, ypos + floorLevel, plattype);
                    }
                }
            }
        }

        private readonly int[] randomItems = { ItemID.HealingPotion, ItemID.IronBar, ItemID.LeadBar, ItemID.GoldBar, ItemID.Apple, ItemID.ManaPotion, ItemID.GoldCoin, ItemID.SilverCoin };
        private void PlaceChest(int specialitem, int xvv, int yvv, int stack = 1)
        {
            int chestIndex = WorldGen.PlaceChest(xvv, yvv);
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
                chest.item[7].SetDefaults(specialitem);
                chest.item[7].stack = stack;
            }
        }
    }
}