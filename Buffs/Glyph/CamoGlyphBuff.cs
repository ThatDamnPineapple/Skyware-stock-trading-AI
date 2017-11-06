using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class CamoGlyphBuff : ModBuff
	{
		public static int _type;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Concealment");
			Description.SetDefault("Being still puts you in stealth\nStealth increases damage by 15% and life regen by 3");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
	}
}
