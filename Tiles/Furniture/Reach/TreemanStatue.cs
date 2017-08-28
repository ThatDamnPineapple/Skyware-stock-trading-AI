using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Furniture.Reach
{
	public class TreemanStatue : ModTile
	{
		public override void SetDefaults()
		{
					Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
 TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.Height = 7;
		TileObjectData.newTile.Width = 7;
        TileObjectData.newTile.CoordinateHeights = new int[]
        {
            16,
            16,
            16,
			16,
			16
		};
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
            name.SetDefault("Statue of the Old Gods");
			AddMapEntry(new Color(60, 244, 55), name);
			disableSmartCursor = true;
						adjTiles = new int[]{ TileID.WorkBenches };
									adjTiles = new int[]{ TileID.Bookcases };
												adjTiles = new int[]{ TileID.Bottles };
												
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = tile.frameY == 36 ? 18 : 16;
			Main.spriteBatch.Draw(mod.GetTexture("Tiles/Furniture/Reach/TreemanStatue_Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Terraria.Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("TreemanStatue"));
		}
	}
}