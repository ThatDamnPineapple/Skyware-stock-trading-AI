using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class FieryPendant : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Fiery Pendant";
            item.width = 18;
            item.height = 18;
            item.toolTip = "Increased melee damage! Melee weapons have a 30% chance to inflict on fire!";
			item.value = Item.buyPrice(0, 8, 0, 0);
			item.rare = 5;

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
