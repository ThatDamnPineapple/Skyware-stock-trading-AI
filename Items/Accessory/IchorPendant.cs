using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class IchorPendant : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ichor Pendant";
            item.width = 18;
            item.height = 18;
            item.toolTip = "Increased melee damage by 6%";
			 item.toolTip2 = "Weapons have a 10% chance to inflict Ichor";
			item.value = Item.buyPrice(0, 6, 0, 0);
			item.rare = 5;

			item.accessory = true;

			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>(mod).IchorPendant = true;
			player.meleeDamage *= 1.06f;
		}
	}
}
