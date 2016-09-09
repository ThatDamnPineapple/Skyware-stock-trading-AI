using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	class RidingCandyCopter : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Candy Copter";
			Main.buffTip[Type] = "GET TO THE CHOPPAH!!!\n ...!\nMy legs won't fit...";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("CandyCopter"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
