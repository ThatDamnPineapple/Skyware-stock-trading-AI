using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class CelestialWill : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Will of Celestial";
            Main.buffTip[Type] = "The Celestils smile upon you";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.1f;
            player.lifeRegen += 5;
        }
    }
}
