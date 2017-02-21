using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class StoneOfSpiritsPast : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stone Of Spirits Past";
			item.toolTip = "Creates orbiting souls to hurt nearby enemies";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 6;
			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MyPlayer>(mod).SoulStone = true;
        }
	}
}
