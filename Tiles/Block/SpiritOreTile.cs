using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Tiles.Block
{
    public class SpiritOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("SpiritOre");   //put your CustomBlock name
            AddMapEntry(new Color(30, 144, 255), "Spirit Ore");
			soundType = 21;
            minPick = 180;
            
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.2f;
                g = 0.4f;
                b = 1.4f;
            }
        }
    }
}