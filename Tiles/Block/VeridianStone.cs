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
	public class VeridianStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("VeridianDirt")] = true;
			AddMapEntry(new Color(0, 191, 255));
			drop = mod.ItemType("SpiritDirtItem");
		}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.4f;
                g = 0.6f;
                b = 1.4f;
            }
        }



public override bool CanExplode(int i, int j)
	{
		return true;
	}
	}
	}

