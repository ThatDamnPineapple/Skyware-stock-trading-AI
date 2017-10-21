using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
    public abstract class GlyphBase : ModItem
    {
		public override bool CanRightClick()
		{
			Player player = Main.player[Main.myPlayer];
			return player.inventory[player.selectedItem].IsWeapon() && player.inventory[player.selectedItem].maxStack == 1;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.FindIndex(x => x.Name == "Tooltip0");
			if (index < 0)
				return;

			Player player = Main.player[Main.myPlayer];
			TooltipLine line;
			if (CanRightClick())
				line = new TooltipLine(mod, "GlyphHint", "Right-click to enchant "+ player.inventory[player.selectedItem].HoverName);
			else
				line = new TooltipLine(mod, "GlyphHint", "Hold the item you want to enchant,\nthen right-click this glyph.");
			line.overrideColor = new Microsoft.Xna.Framework.Color(120, 190, 120);
			tooltips.Insert(index, line);
		}

		public Item EnchantmentTarget(Player player)
		{
			if (player.selectedItem == 58)
				return Main.mouseItem;
			else
				return player.inventory[player.selectedItem];
		}
	}
}