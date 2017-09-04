using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
    public class FrostGlyphBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frostfreeze");
            Description.SetDefault("Increases item crit chance by 6%\nNearby foes are slowed down");
            Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            modPlayer.frostGlyph = true;
        }
    }
}
