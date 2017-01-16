using System;

using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	class BabyMothronBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Baby Mothron";
			Main.buffTip[Type] = "Ever dreamt of riding the almighty Mothron? Well, now you can ride its kid.";

			Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("BabyMothron"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
