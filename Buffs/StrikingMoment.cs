using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class StrikingMoment : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Striking Moment";
            Main.buffTip[Type] = "The next melee hit deals 500% more damage";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 50f;
        }
    }
}
