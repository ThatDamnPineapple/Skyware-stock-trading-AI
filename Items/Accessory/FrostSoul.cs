using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Accessory
{
	public class FrostSoul : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Icy Soul";
			item.width = 32;
            item.height = 32;
			item.toolTip = "Magic attacks may inflict Frostburn";
            item.toolTip2 = "Throwing weapons may inflict Soul Burn";
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 5;
            item.defense = 1;
            item.accessory = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MyPlayer>(mod).icySoul = true;
        }

	}
}
