using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Furniture
{
	public class CandyBowl : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileTable[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Terraria.Item.NewItem(i * 16, j * 16, 64, 32, mod.ItemType("CandyBowl"));
		}
		
		public override void MouseOverFar(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
			player.noThrow = 2;
			player.showItemIcon = true;
				player.showItemIconText = "Take a piece of candy";
				
			}
			public override void RightClick(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
			int effect = Main.rand.Next(100);
			if (effect < 9)
			{
				 player.QuickSpawnItem(mod.ItemType("Taffy"));
			}
			else if (effect < 29)
			{
				 player.QuickSpawnItem(mod.ItemType("Candy"));
			}
			else if (effect < 49)
			{
				 player.QuickSpawnItem(mod.ItemType("ChocolateBar"));
			}
			else if (effect < 59)
			{
				 player.QuickSpawnItem(mod.ItemType("HealthCandy"));
			}
			else if (effect < 69)
			{
				 player.QuickSpawnItem(mod.ItemType("ManaCandy"));
			}
			else if (effect <78)
			{
				 player.QuickSpawnItem(mod.ItemType("CandyApple"));
			}
			else if (effect < 79)
			{
				//trash
			}
			else if (effect< 83)
			{
				player.QuickSpawnItem(mod.ItemType("Apple"));
			}
			else if (effect < 95)
			{
				player.QuickSpawnItem(mod.ItemType("MysteryCandy"));
			}
			else
			{
				player.QuickSpawnItem(mod.ItemType("GoldCandy"));
			}
		}
	}
}