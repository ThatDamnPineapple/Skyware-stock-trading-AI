using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class MedusaEye : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Petrified Eye";
			item.toolTip = "Grants immunity to the Stoned Debuff!";
			item.width = 30;
			item.height = 26;
			item.value = Item.buyPrice(0, 10, 0, 0);
            item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 4;
			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.buffImmune[BuffID.Stoned] = true;
        }
	}
}
