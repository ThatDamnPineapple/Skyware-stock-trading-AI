using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class DazeGlyphBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Daze Dance");
			Description.SetDefault("All attacks inflict confusion\nConfused enemies take damage\nGetting hurt may confuse the player");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			modPlayer.dazeGlyph = true;
		}
	}
}
