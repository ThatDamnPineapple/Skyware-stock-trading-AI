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

namespace SpiritMod.Items.Halloween
{
	public class Candy : ModItem
	{
		public override bool CloneNewInstances
		{
			get { return true; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy");
			Tooltip.SetDefault("Increases all stats slightly");
		}

		private int variant = 0;

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

			variant = Main.rand.Next(CandyNames.Length);
		}


		private static readonly string[] CandyNames = {
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
			"Toblerbone'",
			"Delicious looking Eye",
			"Silky Way",
			"malted silk balls",
			"Cloudheads",
			"red devil hots",
			"Rune Pop",
			"Nursey Kisses",
			"Skullies",
			"Firebolts",
			"Vinewrath Cane",
			"Candy Acorn",
			"Bunnyfinger",
			"Ichorice",
			"Lunatic-tac"
		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.FindIndex(tooltip => tooltip.Name.Equals("ItemName"));
			if (index < 0)
				return;

			TooltipLine name = tooltips.ElementAt(index);
			TooltipLine line = new TooltipLine(mod, "ItemNameSub", CandyNames[variant]);
			line.overrideColor = name.overrideColor;
			tooltips.Insert(index + 1, line);
		}

		public override TagCompound Save()
		{
			TagCompound tag = new TagCompound();
			tag.Add("Variant", variant);
			return tag;
		}

		public override void Load(TagCompound tag)
		{
			variant = tag.GetInt("Variant");
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write((byte)variant);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			variant = reader.ReadByte();
		}
	}
}