using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class ScorchGlyph : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorch Glyph");
			Tooltip.SetDefault("Right-click to enchant your held weapon\nThe enchanted weapon gains: Flare Frenzy\nWielding the weapon consumes you in flames\nGreatly increases the velocity of projectiles\nAttacks may inflict On Fire\nAttacks may also deal extra damage");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;

			item.maxStack = 999;
		}
		public override bool CanRightClick()
		{
			return player.inventory[player.selectedItem].IsWeapon();
		}
		public override void RightClick(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			item.GetGlobalItem<GItem>(mod).FlareGlyph = true;
		}
	}
}