using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class ScarabCharm : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Scarab Charm";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
            item.toolTip = "+1 max minions and +8 minion damage";
            item.rare = 2;

			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.08f;
            player.maxMinions += 1;
		}
	}
}
