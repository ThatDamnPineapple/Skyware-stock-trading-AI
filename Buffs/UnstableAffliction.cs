using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
	public class UnstableAffliction : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[this.Type] = "Unstable Affliction";
			Main.buffTip[this.Type] = "Your wing time is reduced by 50%, infinite flight is disabled";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
            if (player.wingTimeMax <= 0)
            {
                player.wingTimeMax = 0;
            }
            player.wingTimeMax /= 2;
        }
	}
}