using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
	class BeetleFortitude : ModBuff
	{
		public static ModBuff _ref;

		int stacks = 1;

		public override void SetDefaults()
		{
			Main.buffName[this.Type] = "Beetle Fortitude";
			Main.buffTip[Type] = "Each strike fortifies you...";
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PlayerHook modPlayer = player.GetModPlayer<PlayerHook>(mod);
			player.endurance += modPlayer.beetleStacks * 0.01f;
		}

		public override bool ReApply(Player player, int time, int buffIndex)
		{
			PlayerHook modPlayer = player.GetModPlayer<PlayerHook>(mod);
			if (modPlayer.beetleStacks < 15)
			{
				modPlayer.beetleStacks++;
			}
			return false;
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
			PlayerHook modPlayer = Main.player[Main.myPlayer].GetModPlayer<PlayerHook>(mod);
			tip += "\nDamage taken is reduced by " + modPlayer.beetleStacks + "%";
			rare = modPlayer.beetleStacks >> 1;
		}
	}
}
