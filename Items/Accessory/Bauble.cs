using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Accessory
{
	public class Bauble : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Winter's Bauble";
			item.width = 18;
            item.height = 18;
			item.toolTip = "When under half health, damage dealt is reduced by 30%\n When under half health, you are also surrounded by a shield that nullifies projectiles for 6 seconds\n Two minute cooldown";
			item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 5;
			item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MyPlayer>(mod).Bauble = true;
        }

	}
}
