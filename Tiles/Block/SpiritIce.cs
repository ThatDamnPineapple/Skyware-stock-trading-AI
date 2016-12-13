using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.World.Generation;

namespace SpiritMod.Tiles.Block
{
	public class SpiritIce : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(70, 130, 180));
		//	drop = mod.ItemType("SpiritIceItem");
		}

public override bool CanExplode(int i, int j)
	{
		return true;
	}
	public override void RandomUpdate(int i, int j)
		{
		for (int A = i - 1; A < i + 1; A++)
		{
				for (int B = i - 1; B < i + 1; B++)
				{
					if (Main.tile[A,B] != null)
					{
					if (Main.rand.Next(1000) == 1)
					{
						if (Main.tile[A,B].type == 0)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritDirt"));
						}
						else if (Main.tile[A,B].type == 1)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritStone"));
						}
						else if (Main.tile[A,B].type == 5)
						{ 
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritWood"));
						}
						else if (Main.tile[A,B].type == 161)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritIce"));
						}
						else if (Main.tile[A,B].type == 53)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritSand"));
						}
						else if (Main.tile[A,B].type == 3)
						{ 
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritGrass"));
						}
					}
					}
				}
			} 
		}
	}
	}

