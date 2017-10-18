using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Ambient.SpookyGrass
{
	public class SpookyGrassA5 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.addTile(Type);
			Main.tileCut[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			//Main.tileBlockLight[Type] = true;
			dustType = 5;
			Main.tileLighted[Type] = false;
			TileObjectData.addTile(Type);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			}; 
			soundType = 6;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 2;
		}
		
		
		
	}
}