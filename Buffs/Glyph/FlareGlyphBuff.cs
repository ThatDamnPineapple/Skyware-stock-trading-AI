using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class FlareGlyphBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Flare Frenzy");
			Description.SetDefault("The player is engulfed in flames\nGreatly increases the velocity of projectiles\nAttacks may inflict On Fire\nAttacks may also deal extra damage");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			modPlayer.flareGlyph = true;
		}
	}
}
