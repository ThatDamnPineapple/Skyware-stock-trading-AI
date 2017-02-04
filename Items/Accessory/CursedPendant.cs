using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class CursedPendant : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cursed Pendant";
            item.width = 18;
            item.height = 18;
            item.toolTip = "Increases melee damage by 6%";
			 item.toolTip2 = "Weapons have a 15% chance to inflict Cursed Inferno";
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 4;

			item.accessory = true;

			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>(mod).CursedPendant = true;
			player.meleeDamage *= 1.06f;
		}
	}
}
