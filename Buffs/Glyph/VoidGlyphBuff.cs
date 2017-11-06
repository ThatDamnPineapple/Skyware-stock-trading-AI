using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class VoidGlyphBuff : ModBuff
	{
		public static int _type;

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
			player.endurance += modPlayer.voidStacks * 0.05f;
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
			MyPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(mod);
			tip = "Damage taken is reduced by " + modPlayer.voidStacks * 5 + "%";
			rare = modPlayer.voidStacks >> 1;
		}
	}
}
