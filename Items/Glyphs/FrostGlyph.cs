using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class FrostGlyph : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Glyph");
			Tooltip.SetDefault("Right-click to enchant the held weapon\nThe enchanted weapon gains: Frostfreeze\nFrostfreeze increases critical strike chance by 6% and causes nearby foes to slow down");
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
			item.GetGlobalItem<GItem>(mod).FrostGlyph = true;
		}
	}
}