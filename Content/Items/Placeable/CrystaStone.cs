﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ModOfFantasies.Content.Items.Placeable
{
    public class CrystaStone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(25, 50, 255));
        }
    }
}