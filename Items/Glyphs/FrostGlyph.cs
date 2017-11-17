using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class FrostGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Frostfreeze\nFrostfreeze increases critical strike chance by 6% and causes nearby foes to slow down");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Frost);
		}
	}
}