using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class FieryPendant : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Adamantite band";
			item.toolTip = "Increased melee damage";
			item.toolTip2 = "Melee weapons have a 30% chance to inflict on fire!";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if(Main.rand.Next(10) > 3)
			{
				player.magmaStone = true;
			}
			player.meleeDamage *= 1.06f;
		}
	}
}
