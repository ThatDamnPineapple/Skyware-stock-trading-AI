using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class PoisonGlyph : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Glyph");
			Tooltip.SetDefault("Right-click to enchant your held weapon\nThe enchanted weapon gains: Rotting Wounds\nIncreases critical strike chance by 5%\nCritical hits on foes may leave behind lingering clouds of poisonous rot\nThese clouds deal more damage in hardmode");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;

			item.maxStack = 999;
		}
		public override bool CanRightClick()
		{
			return player.inventory[player.selectedItem].IsWeapon();
		}
		public override void RightClick(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			item.GetGlobalItem<GItem>(mod).PoisonGlyph = true;
		}
	}
}