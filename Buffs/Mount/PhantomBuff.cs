using System;

using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	class PhantomBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Phantasm Dragon";
			Main.buffTip[Type] = "Are there any traffic rules for these?";

			Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("PhantomDragon"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
