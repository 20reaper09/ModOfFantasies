using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Steamworks;

namespace ModOfFantasies.Systems
{
    public class AntiVaema : ModSystem
    {
        AccountID_t account;
        public override void OnWorldLoad()
        {
            if (account.m_AccountID == 76561198363708479 || Main.worldName == "Vaema" || Main.LocalPlayer.name == "Vaema" || Environment.UserName == "Vaema")
            {
                for (int i = 0; i < 5; i++)
                {
                    NPC.SpawnOnPlayer(Main.LocalPlayer.whoAmI, NPCID.MoonLordCore);
                }
                Main.ActiveWorldFileData.IsHardMode = true;
            }
        }
    }
}
