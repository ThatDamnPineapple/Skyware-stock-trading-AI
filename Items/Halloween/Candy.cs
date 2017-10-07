using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Collections.ObjectModel;

namespace SpiritMod.Items.Halloween
{
	public class Candy : ModItem
	{
		public static int _type;

		public override bool CloneNewInstances => true;

		public int Variant
			{ get; internal set; }


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy");
			Tooltip.SetDefault("Increases all stats slightly");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.rare = 2;
			item.maxStack = 1;

			item.useStyle = 2;
			item.useTime = item.useAnimation = 20;

			item.consumable = true;
			item.autoReuse = false;

			item.buffType = mod.BuffType("CandyBuff");
			item.buffTime = 14400;

			item.UseSound = SoundID.Item2;

			Variant = Main.rand.Next(CandyNames.Count);
		}

		
		internal static readonly ReadOnlyCollection<string> CandyNames = 
			Array.AsReadOnly(new string[]
		{
			"Popstone",
			"Three Muskets",
			"Lhizzlers",
			"Moon Jelly Beans",
			"Silk Duds",
			"Necro Wafers",
			"Blinkroot Pop",
			"Gummy Slimes",
			"Cry Goblin",
			"Sour patch Slimes",
			"Stardust Burst",
			"Hellfire Tamales",
			"Blinkroot Patty",
			"Xenowhoppers",
			"Gem&Ms",
			"100,000 copper bar",
			"Toblerbone",
			"Delicious Looking Eye",
			"Silky Way",
			"Malted Silk Balls",
			"Cloudheads",
			"Red Devil Hots",
			"Rune Pop",
			"Nursey Kisses",
			"Skullies",
			"Firebolts",
			"Vinewrath Cane",
			"Candy Acorn",
			"Bunnyfinger",
			"Ichorice",
			"Lunatic-tac"
		});

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.FindIndex(tooltip => tooltip.Name.Equals("ItemName"));
			if (index >= 0)
			{
				TooltipLine name = tooltips.ElementAt(index);
				TooltipLine line = new TooltipLine(mod, "ItemNameSub", "'"+ CandyNames[Variant] +"'");
				tooltips.Insert(index + 1, line);
			}

			if (CanRightClick())
				tooltips.Add(new TooltipLine(mod, "RightclickHint", "Right click to put into Candy Bag"));
		}

		public override bool ItemSpace(Player player)
		{
			Item[] inv = player.inventory;
			for (int i = 0; i < 50; i++)
			{
				if (inv[i].IsAir || inv[i].type != CandyBag._type)
					continue;
				if (!((CandyBag)inv[i].modItem).Full)
					return true;
			}
			return false;
		}

		public override bool OnPickup(Player player)
		{
			Item[] inv = player.inventory;
			for (int i = 0; i < 50; i++)
			{
				if (inv[i].IsAir || inv[i].type != CandyBag._type)
					continue;
				if (((CandyBag)inv[i].modItem).TryAdd(Variant))
				{
					ItemText.NewText(item, 1);
					Main.PlaySound(7, (int)player.position.X, (int)player.position.Y);
					return false;
				}
			}
			return true;
		}

		public override bool CanRightClick()
		{
			return ItemSpace(Main.player[Main.myPlayer]);
		}

		public override void RightClick(Player player)
		{
			Item[] inv = player.inventory;
			for (int i = 0; i < 50; i++)
			{
				if (inv[i].IsAir || inv[i].type != CandyBag._type)
					continue;
				if (((CandyBag)inv[i].modItem).TryAdd(Variant))
				{
					Main.PlaySound(7, (int)player.position.X, (int)player.position.Y);
					return;
				}
			}
			//No bags with free space found.

			//Needed to counter the default consuption.
			item.stack++;
		}
		

		public override TagCompound Save()
		{
			TagCompound tag = new TagCompound();
			tag.Add("Variant", Variant);
			return tag;
		}

		public override void Load(TagCompound tag)
		{
			Variant = tag.GetInt("Variant");
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write((byte)Variant);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			Variant = reader.ReadByte();
		}
	}
}
