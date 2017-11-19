using Terraria.ModLoader.IO;

namespace SpiritMod.Items.Glyphs
{
	public class BloodGlyph : GlyphBase
	{
		public override string Texture => SpiritMod.EMPTY_TEXTURE;

		public override void Load(TagCompound tag)
		{
			item.SetDefaults(SanguineGlyph._type);
		}
	}
}