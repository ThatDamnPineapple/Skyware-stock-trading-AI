using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class PhaseGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phase Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Phase Flux\nWhile wielding the weapon, you gain 20% increased movement speed and immunity to knockback\nReduces defense by 5");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Phase);
		}
	}
}