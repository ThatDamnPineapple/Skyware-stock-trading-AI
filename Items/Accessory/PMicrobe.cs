using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class PMicrobe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Plaguebearer Microbe";
            item.width = 28;
			item.height = 24;
            item.toolTip = "Increases max life by 10 at the cost of 1 defense";
            item.value = Item.buyPrice(0, 0, 75, 0);
			item.rare = 1;

			item.accessory = true;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.statLifeMax2 += 10;
            player.statDefense -= 1;
        }
	}
}
