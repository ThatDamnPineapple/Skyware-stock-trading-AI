using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpiritMod.Items.Halloween
{
	class CandyBag : ModItem
	{
		public const ushort MaxCandy = 999;
		public static int _type;


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy Bag");
			Tooltip.SetDefault("Holds up to "+ MaxCandy +" pieces of candy");
		}


		private int pieces;
		private ushort[] candy;

		public bool ContainsCandy => pieces > 0;
		public bool Full => pieces >= MaxCandy;

		public CandyBag()
		{
			pieces = 0;
			candy = new ushort[Candy.CandyNames.Count];
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.rare = 3;
			item.maxStack = 1;
		}

		//public override bool CanUseItem(Player player)
		//{
		//	return ContainsCandy;
		//}

		//public override bool UseItem(Player player)
		//{
		//	PrintContents();
		//	int total = 0;
		//	for (int i = candy.Length-1; i >= 0; i--)
		//		total += candy[i];
		//	int remove = Main.rand.Next(total);
		//	for (int i = candy.Length-1; i >= 0; i--)
		//	{
		//		if (remove < candy[i])
		//		{
		//			candy[i]--;
		//			break;
		//		}
		//		remove -= candy[i];
		//	}
		//	return false;
		//}

		public bool TryAdd(int variant)
		{
			if (pieces >= MaxCandy)
				return false;

			candy[variant]++;
			pieces++;
			return true;
		}

		public override bool CanRightClick()
		{
			return ContainsCandy;
		}

		public override void RightClick(Player player)
		{
			if (pieces <= 0)
				return;
			int remove = Main.rand.Next(pieces);
			int i = candy.Length-1;
			for (; i >= 0; i--)
			{
				if (remove < candy[i])
					break;
				
				remove -= candy[i];
			}
			candy[i]--;
			pieces--;
			int slot = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, Candy._type);
			Item item = Main.item[slot];
			item.velocity.X = 4 * player.direction + player.velocity.X;
			item.velocity.Y = -2f;
			item.noGrabDelay = 100;
			((Candy)Main.item[slot].modItem).Variant = i;
			Item[] inv = player.inventory;
			for (int j = 0; j < 50; j++)
			{
				if (!inv[j].IsAir)
					continue;
				inv[j] = Main.item[slot];
				Main.item[slot] = new Item();
			}
			if (Main.netMode == 1 && Main.item[slot].type != 0)
			{
				NetMessage.SendData(21, -1, -1, null, slot, 1f);
			}

			//Needed to counter the default consuption.
			this.item.stack++;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (!ContainsCandy)
				return;

			TooltipLine line = new TooltipLine(mod, "BagContents", "Contains " + pieces + (pieces==1?" piece":" pieces") +" of Candy");
			tooltips.Add(line);
			line = new TooltipLine(mod, "RightclickHint", "Right click to take a piece of Candy");
			tooltips.Add(line);
		}

		public void PrintContents()
		{
			Main.NewText("Candy Bag ["+ candy.Length +"]");
			for (int i = candy.Length-1; i >= 0; i--)
			{
				if (candy[i] > 0)
					Main.NewText(Candy.CandyNames[i] +" ("+ candy[i] +")");
			}
		}


		public override TagCompound Save()
		{
			TagCompound tag = new TagCompound();
			int[] arr = new int[candy.Length];
			for (int i = candy.Length-1; i >= 0; i--)
				arr[i] = candy[i];
			tag.Add("candy", arr);
			return tag;
		}

		public override void Load(TagCompound tag)
		{
			pieces = 0;
			int[] arr = tag.GetIntArray("candy");
			for (int i = Math.Min(arr.Length, candy.Length) - 1; i >= 0; i--)
				pieces += (candy[i] = (ushort)arr[i]);
		}

		public override void NetSend(BinaryWriter writer)
		{
			for (int i = candy.Length-1; i >= 0; i--)
				writer.Write(candy[i]);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			pieces = 0;
			for (int i = candy.Length-1; i >= 0; i--)
				pieces += candy[i] = reader.ReadUInt16();
		}

		public override ModItem Clone(Item item)
		{
			CandyBag clone = (CandyBag)NewInstance(item);
			Array.Copy(candy, clone.candy, candy.Length);
			clone.pieces = pieces;
			return clone;
		}
	}
}
