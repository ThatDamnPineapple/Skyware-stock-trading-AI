using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class PMicrobe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Plaguebearer Microbe";
			item.toolTip = "Increases Max Life at the Cost of Defense";
            item.width = 28;
			item.height = 24;
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.rare = 2;
			item.accessory = true;
            item.defense -= 1;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.statLifeMax2 += 10;
        }
	}
}
