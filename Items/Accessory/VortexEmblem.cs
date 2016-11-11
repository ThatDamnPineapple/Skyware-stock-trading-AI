using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class VortexEmblem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Vortex Emblem";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Increases ranged damage and critical chance.";
            item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 10;

			item.accessory = true;

			item.defense = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.5f;
			player.rangedCrit += 2;
		}
	}
}
