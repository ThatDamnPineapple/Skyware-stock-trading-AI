using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class BloodGlyph : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Glyph");
			Tooltip.SetDefault("Right-click to enchant your held weapon\nThe enchanted weapon gains: Sanguine Strike\nAttacks inflict Blood Corruption\nHitting foes struck with Blood Corruption may steal life");
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
			item.GetGlobalItem<GItem>(mod).BloodGlyph = true;
		}
	}
}