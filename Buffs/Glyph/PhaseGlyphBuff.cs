using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class PhaseGlyphBuff : ModBuff
	{
		public static int _type;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Phase Flux");
			Description.SetDefault("Wielding this weapon grants you 20% increased movement speed and immunity to knockback\nReduces defense by 5");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
	}
}
