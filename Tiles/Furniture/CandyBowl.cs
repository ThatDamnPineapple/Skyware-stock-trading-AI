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
			animationFrameHeight = 36;
			Main.tileTable[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 32, mod.ItemType("CandyBowl"));
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			if (Main.dayTime || Main.gameMenu)
			{
				frame = 0;
				return;
			}
			MyPlayer player = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
			frame = player.candyInBowl > 0 ? 1 : 0;
		}

		public override void MouseOverFar(int i, int j)
		{
			if (Main.dayTime)
				return;

			Player player = Main.player[Main.myPlayer];
			if (player.GetModPlayer<MyPlayer>().candyInBowl <= 0)
				return;

			player.noThrow = 2;
			//player.showItemIcon = true;
			player.showItemIconText = "Take a piece of candy";
		}

		public override void RightClick(int i, int j)
		{
			if (Main.dayTime)
				return;

			Player player = Main.player[Main.myPlayer];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (modPlayer.candyInBowl <= 0)
				return;

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
			modPlayer.candyInBowl--;
		}
	}
}