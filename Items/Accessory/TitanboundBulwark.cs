using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class TitanboundBulwark : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Titanbound Bulwark";
			item.toolTip = "Gives defense, but are too heavy to carry";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 7;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.velocity.X = 0;
			 if (player.velocity.Y < 0)
			 {
				 player.velocity.Y = 0.4f;
			 }
			 player.jumpSpeedBoost -= 2f;
		}
	}
}
