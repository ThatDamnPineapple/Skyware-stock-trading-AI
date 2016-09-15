using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.World.Generation;

namespace SpiritMod.Tiles.Block
{
	public class SpiritDirt : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("SpiritGrass")] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(173, 216, 230));
			drop = mod.ItemType("SpiritDirtItem");
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
					if (Main.tile[A, B].active())
					{
					if (Main.rand.Next(2000) == 1)
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
						else if (Main.tile[A,B].type == 161)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritIce"));
						}
						else if (Main.tile[A,B].type == 5)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritWood"));
						}
						else if (Main.tile[A,B].type == 53)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritSand"));
						}
						else if (Main.tile[A,B].type == 3)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritGrass"));
						}
					}
					}
				}
			} 
		}
	}
	}

