using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SpiritMod.Tiles.Block
{
	public class ReachGrassTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("ReachGrassTile")] = true;
			Main.tileBlendAll[this.Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(0, 255, 191));
			drop = mod.ItemType("ReachGrass");
        }
    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return 20;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.028f;
                g = 0.153f;
                b = 0.081f;
            }
        }
	}
}

