using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	public class BasiliskMountBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Basilisk";
			Main.buffTip[Type] = "A beast from the past...";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("Basilisk"), player, false);
			player.buffTime[buffIndex] = 10;
		}
	}
}
