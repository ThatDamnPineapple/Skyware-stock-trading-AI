using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
	public class CarnivorousPlantMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Carnivorous Plant";
			Main.buffTip[Type] = "???";

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("CarnivorousPlantMinion")] > 0)
				modPlayer.carnivorousPlantMinion = true;

			if (!modPlayer.carnivorousPlantMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
