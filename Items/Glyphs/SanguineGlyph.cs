using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class SanguineGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Sanguine Strike\nAttacks inflict Blood Corruption\nHitting foes struck with Blood Corruption may steal life");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Sanguine);
		}


		public static void BloodCorruption(Player player, NPC target)
		{
			if (target.FindBuffIndex(Buffs.BCorrupt._type) > -1)
			{
				player.HealEffect(3);
				player.statLife += 3;
			}

			if (Main.rand.Next(5) == 0)
				target.AddBuff(Buffs.BCorrupt._type, 300);
		}

		public static void BloodCorruption(Player player, Player target)
		{
			if (target.FindBuffIndex(Buffs.BCorrupt._type) > -1)
			{
				player.HealEffect(3);
				player.statLife += 3;
			}

			if (Main.rand.Next(5) == 0)
				target.AddBuff(Buffs.BCorrupt._type, 300, false);
		}
	}
}