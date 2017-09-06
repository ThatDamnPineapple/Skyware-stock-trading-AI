using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class PhaseGlyph : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phase Glyph");
			Tooltip.SetDefault("Right-click to enchant your held weapon\nThe enchanted weapon gains: Phase Flux\nWhile wielding the weapon, you gain 20% increased movement speed and immunity to knockback\nReduces defense by 5");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;

			item.maxStack = 999;
		}
		public override bool CanRightClick()
		{
			return player.inventory[player.selectedItem].IsWeapon();
		}
		public override void RightClick(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			item.GetGlobalItem<GItem>(mod).PhaseGlyph = true;
		}
	}
}