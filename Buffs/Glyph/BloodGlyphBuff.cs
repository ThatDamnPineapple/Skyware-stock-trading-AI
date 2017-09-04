using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
    public class BloodGlyphBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sanguine Strike");
            Description.SetDefault("This item inflicts Blood Corruption\nStriking enemies with Blood Corruption may steal life");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            modPlayer.bloodGlyph = true;
        }
    }
}
