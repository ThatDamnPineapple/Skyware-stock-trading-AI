using System;

using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	class DiabolicPlatformBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "";
			Main.buffTip[Type] = "";

			Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("DiabolicPlatform"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
