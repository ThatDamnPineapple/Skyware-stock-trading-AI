using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
	public class CragboundMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Atlas";
			Main.buffTip[Type] = "???";

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("CragboundMinion")] > 0)
				modPlayer.cragboundMinion = true;

			if (!modPlayer.cragboundMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
