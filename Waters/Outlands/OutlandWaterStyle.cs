using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Waters.Outlands
{
	public class OutlandWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
			return Main.bgStyle == mod.GetSurfaceBgStyleSlot("OutlandsSurfaceBgStyle");
		}

		public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("OutlandWaterfallStyle");
		}

		public override int GetSplashDust()
		{
			return mod.DustType("OutlandWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/OutlandDroplet");
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor()
		{
			return Color.Purple;
		}
	}
}