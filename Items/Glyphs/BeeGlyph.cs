using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class BeeGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Wasp Call\nReduces movement speed by 7%\nAttacks may release bees");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Bee);
		}


		public static void ReleaseBees(Player owner, Entity target, int damage)
		{
			if (owner.whoAmI != Main.myPlayer)
				return;
			int count = Main.rand.Next(1, 3);
			for (int i = 0; i < count; i++)
			{
				Vector2 velocity = target.velocity;
				velocity.X += (float)Main.rand.Next(-35, 36) * 0.02f;
				velocity.Y += (float)Main.rand.Next(-35, 36) * 0.02f;
				Projectile.NewProjectile(target.Center, velocity, owner.beeType(), owner.beeDamage((int)(damage * .4f)), owner.beeKB(0f), Main.myPlayer);
			}
		}
	}
}