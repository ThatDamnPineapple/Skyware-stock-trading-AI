using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
	class VoidGlyphBuff1 : ModBuff
	{
		public static ModBuff _ref;

		int stacks = 1;

		public override void SetDefaults()
		{
            DisplayName.SetDefault("CollapsingVoid");
            Description.SetDefault("");
            Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			player.endurance += modPlayer.glyphStacks * 0.05f;
            modPlayer.voidGlyph1 = true;
		}

		public override bool ReApply(Player player, int time, int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.glyphStacks < 2)
			{
				modPlayer.glyphStacks++;
			}
			return false;
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
            MyPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(mod);
			tip += "\nDamage taken is reduced by " + (modPlayer.glyphStacks * 5) + "%";
			rare = modPlayer.glyphStacks >> 1;
		}
	}
}
