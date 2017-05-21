using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class Earthwrought : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Earthwrought";
            Main.buffTip[Type] = "The Earth seeps through you, increasing life regen";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            if (Main.rand.Next(4) == 0)
            {

                Dust.NewDust(player.position, player.width, player.height, 44);
            }
        }
    }
}
