using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class BeeGlyphBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Flare Frenzy");
			Description.SetDefault("Attacks may release multiple bees\nReduces movement speed by 7%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed -= 0.07f;
			player.maxRunSpeed -= 0.07f;
		}
	}
}
