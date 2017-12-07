using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class VeilGlyph : GlyphBase, Glowing
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		Microsoft.Xna.Framework.Graphics.Texture2D Glowing.Glowmask(out float bias)
		{
			bias = GLOW_BIAS;
			return _textures[1];
		}

		public override GlyphType Glyph => GlyphType.Veil;
		public override Microsoft.Xna.Framework.Graphics.Texture2D Overlay => _textures[2];
		public override string Effect => "Shielding Veil";
		public override string Addendum =>
			"After 8 seconds of not taking damage you gain Phantom Veil\n"+
			"This Veil will increase life regen and block the next attack";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Veil Glyph");
			Tooltip.SetDefault(
				"+5% Attck speed\n"+
				"After 8 seconds of not taking damage you gain Phantom Veil\n"+
				"This Veil will increase life regen and block the next attack");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;

			item.maxStack = 999;
		}


		public static void Block(Player player)
		{
			player.immune = true;
			player.immuneTime = 80;
			if (player.longInvince)
				player.immuneTime += 40;
			for (int i = 0; i < player.hurtCooldowns.Length; i++)
			{
				player.hurtCooldowns[i] = player.immuneTime;
			}
			if (player.whoAmI == Main.myPlayer)
			{
				//NetMessage.SendData(62, -1, -1, "", this.whoAmI, 2f, 0f, 0f, 0, 0, 0);
			}
		}
	}
}