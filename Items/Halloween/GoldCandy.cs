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
	public class GoldCandy : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Candy");
			Tooltip.SetDefault("Can't be eaten, but may sell for a lot!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.rare = 2;
			item.maxStack = 1;
			item.value = 100000;
			item.useStyle = 2;
			item.useTime = item.useAnimation = 20;

			item.consumable = true;
			item.autoReuse = false;

			item.UseSound = SoundID.Item2;

			
		}
	}
}
