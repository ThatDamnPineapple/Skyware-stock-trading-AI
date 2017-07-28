using System;

using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Mount
{
	class AntlionBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Antlion Swarmer");
            Description.SetDefault("Its sharp claws aide your digging");

            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("AntlionMount"), player);
			player.buffTime[buffIndex] = 10;

            player.pickSpeed -= 0.05f;
		}
	}
}
