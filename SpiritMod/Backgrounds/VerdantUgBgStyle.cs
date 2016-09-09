using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Backgrounds
{
	public class VerdantUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(mod).ZoneVerdant;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/VerdantBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/VerdantBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/VerdantBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/VerdantBiomeUG3");
		}
	}
}