using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class ScorchGlyph : GlyphBase
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorch Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Flare Frenzy\nWielding the weapon consumes you in flames\nGreatly increases the velocity of projectiles\nAttacks may inflict On Fire\nAttacks may also deal extra damage");
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
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).FlareGlyph = true;
		}


		public static void Scorch(NPC target, bool crit)
		{
			if (Main.rand.Next(10) == 0)
				target.StrikeNPC(15, 0f, 0, crit);

			target.AddBuff(BuffID.OnFire, 180);
		}

		public static void Scorch(Player target, bool crit)
		{
			if (Main.rand.Next(10) == 0)
				target.Hurt(PlayerDeathReason.ByCustomReason(target.name +" got evaporated."), 15, 0, true, false, crit);

			target.AddBuff(BuffID.OnFire, 180, false);
		}
	}
}