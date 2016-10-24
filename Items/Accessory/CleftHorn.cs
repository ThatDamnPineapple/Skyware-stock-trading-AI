using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class CleftHorn : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cleft Horn";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Grants +4% melee damage and crit chance";
            item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 1;

			item.accessory = true;

			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 4;
			player.meleeDamage += 0.04f;
		}
	}
}
