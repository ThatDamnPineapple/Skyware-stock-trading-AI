using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace SpiritMod.Tiles.Block
{
	public class SpiritTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("SpiritMod");
			}
		}

		public override int CreateDust()
		{
			return 1;
		}

		//public override int GrowthFXGore()
		//{
		//	return mod.GetGoreSlot("Gores/ExampleTreeFX");
		//}

		public override int DropWood()
		{
			return mod.ItemType("SpiritWood");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/Block/SpiritTree");
		}

		public override Texture2D GetTopTextures()
		{
			return mod.GetTexture("Tiles/Block/SpiritTree_Tops");
		}

		public override Texture2D GetBranchTextures()
		{
			return mod.GetTexture("Tiles/Block/SpiritTree_Branches");
		}
	}
}