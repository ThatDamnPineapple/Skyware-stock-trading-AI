using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
    public class PoisonGlyphBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rotting Wound");
            Description.SetDefault("Increases critical strike chance by 5%\nCritical strikes may release clouds of poison\nThese clouds deal more damage in hardmode");
            Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            modPlayer.poisonGlyph = true;
        }
    }
}
