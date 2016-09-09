using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	public class DrakomireMountBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Drakomire";
			Main.buffTip[Type] = "So you have tamed a Celestial Invader...";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("Drakomire"), player, false);
			player.buffTime[buffIndex] = 10;
		}
	}
}
