using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
	public class UnboundSoulMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Unbound Soul";
			Main.buffTip[Type] = "";

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("UnboundSoul")] > 0)
			{
				modPlayer.unboundSoulMinion = true;
			}
			if (!modPlayer.unboundSoulMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
