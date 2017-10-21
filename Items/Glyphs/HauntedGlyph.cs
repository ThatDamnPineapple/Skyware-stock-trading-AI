using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class HauntedGlyph : GlyphBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Haunted Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Collapsing Void\nWielding the weapon grants you Collapsing Void, which reduces damage taken by 5%\nLanding a critical hit on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\nHitting foes when having more than one stack of Collapsing Void may generate Void Stars");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 7;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).HauntedGlyph = true;
		}
	}
}