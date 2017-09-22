using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class VoidGlyphBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Collapsing Void");
			Description.SetDefault("Reduces damage taken by 5%\nAttacks may grant you up to three stacks of Collapsing Void\nDamage reduction from Collapsing Void caps at 15%\nAttacks may generate void singularities");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			modPlayer.voidGlyph = true;
			player.endurance += .05f;
		}
	}
}
