using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class SoulFlare : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Soul Flare";
            Main.buffTip[Type] = "The lifeforce of the universe is destroying you";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 30;
            npc.GetModInfo<NInfo>(mod).SoulFlare = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
                player.lifeRegen = 0;
            player.lifeRegen -= 34;
            player.statDefense -= 6;

            if (Main.rand.Next(4) == 1)
            {

                Dust.NewDust(player.position, player.width, player.height, 187);
            }
        }
    }
}
