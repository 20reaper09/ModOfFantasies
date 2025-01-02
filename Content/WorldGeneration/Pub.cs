using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria;

namespace ModOfFantasies.Content.WorldGeneration
{
    public class Pub : GenPass
    {
        public Pub(string name, float loadWeight) : base(name, loadWeight) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating an underground pub...";

            int spawnX = Main.spawnTileX;
            int spawnY = Main.spawnTileY;
            int houseBaseX = spawnX + Main.rand.Next(-200, 200);
            int houseBaseY = spawnY + 80;
            for (int x = houseBaseX + 20; x < houseBaseX + 31; x++)
            {
                for (int y = houseBaseY - 13; y < houseBaseY + 3; y++)
                {
                    if (y == houseBaseY + 1 || y == houseBaseY + 2)
                    {
                        continue;
                    }
                    Main.tile[x, y].ClearEverything();
                }
            }

            //floor
            for (int i = 0; i < 11; i++)
            {
                int x = houseBaseX + 30 - i;
                int y = houseBaseY;
                Main.tile[x, y].ClearEverything();
                WorldGen.PlaceTile(x, y, TileID.GrayBrick);
            }

            //walls
            for (int x = 0; x < 9; x++)
            {
                for (int y = 1; y < 13; y++)
                {
                    int tileX = houseBaseX + 29 - x;
                    int tileY = houseBaseY - y;
                    Main.tile[tileX, tileY].ClearEverything();
                    WorldGen.PlaceWall(tileX, tileY, WallID.GrayBrick);
                }
            }

            //platform
            for (int i = 0; i < 11; i++)
            {
                int x = houseBaseX + 30 - i;
                int y = houseBaseY - 7;
                WorldGen.PlaceTile(x, y, TileID.Platforms);
            }

            //roof
            for (int i = 0; i < 11; i++)
            {
                int x = houseBaseX + 30 - i;
                int y = houseBaseY - 13;
                Main.tile[x, y].ClearEverything();
                WorldGen.PlaceTile(x, y, TileID.GrayBrick);
            }

            //right side
            for (int i = 4; i < 13; i++)
            {
                int x = houseBaseX + 30;
                int y = houseBaseY - i;
                Main.tile[x, y].ClearEverything();
                WorldGen.PlaceTile(x, y, TileID.GrayBrick);
            }

            //left side
            for (int i = 4; i < 13; i++)
            {
                int x = houseBaseX + 20;
                int y = houseBaseY - i;
                Main.tile[x, y].ClearEverything();
                WorldGen.PlaceTile(x, y, TileID.GrayBrick);
            }

            //torches
            WorldGen.PlaceTile(houseBaseX + 21, houseBaseY - 12, TileID.Torches);
            WorldGen.PlaceTile(houseBaseX + 29, houseBaseY - 12, TileID.Torches);

            WorldGen.PlaceTile(houseBaseX + 21, houseBaseY - 6, TileID.Torches);
            WorldGen.PlaceTile(houseBaseX + 29, houseBaseY - 6, TileID.Torches);

            //table
            WorldGen.PlaceTile(houseBaseX + 23, houseBaseY - 8, TileID.Tables);
            WorldGen.PlaceTile(houseBaseX + 23, houseBaseY - 1, TileID.Tables);

            //chairs
            WorldGen.PlaceTile(houseBaseX + 25, houseBaseY - 8, TileID.Chairs);
            WorldGen.PlaceTile(houseBaseX + 25, houseBaseY - 1, TileID.Chairs);

            //doors
            WorldGen.PlaceTile(houseBaseX + 20, houseBaseY - 1, TileID.ClosedDoor);
            WorldGen.PlaceTile(houseBaseX + 30, houseBaseY - 1, TileID.ClosedDoor);

            //top chest
            int[] randomItems = { ItemID.HealingPotion, ItemID.IronBar, ItemID.GoldBar, ItemID.Apple, ItemID.ManaPotion };
            int chestIndex = WorldGen.PlaceChest(houseBaseX + 27, houseBaseY - 8);
            if (chestIndex >= 0)
            {
                Chest chest = Main.chest[chestIndex];
                for (int i = 0; i < 4; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[4] = new Item();
                chest.item[4].SetDefaults(ItemID.GoldenDelight);
                chest.item[4].stack = 1;
            }

            //bottom chest
            int chestIndex1 = WorldGen.PlaceChest(houseBaseX + 27, houseBaseY - 1);
            if (chestIndex1 >= 0)
            {
                Chest chest = Main.chest[chestIndex1];
                for (int i = 0; i < 4; i++)
                {
                    int randomItem = randomItems[Main.rand.Next(randomItems.Length)];
                    chest.item[i] = new Item();
                    chest.item[i].SetDefaults(randomItem);
                    chest.item[i].stack = Main.rand.Next(1, 11);
                }
                chest.item[4] = new Item();
                chest.item[4].SetDefaults(ItemID.GoldenDelight);
                chest.item[4].stack = 1;
            }
        }
    }
}