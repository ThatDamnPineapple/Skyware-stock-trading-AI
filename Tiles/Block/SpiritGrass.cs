using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SpiritMod.Tiles.Block
{
	public class SpiritGrass : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			SetModTree(new SpiritTree());
			Main.tileMerge[Type][mod.TileType("SpiritDirt")] = true;
			Main.tileBlendAll[this.Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(0, 191, 255));
			drop = mod.ItemType("SpiritDirtItem");
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("SpiritSapling");
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			{
				r = 0.4f;
				g = 0.6f;
				b = 1.4f;
			}
		}

	}
}

