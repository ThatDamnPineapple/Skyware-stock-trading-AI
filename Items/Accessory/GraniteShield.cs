using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class GraniteShield : ModItem
	{
		private bool Meme;
		public override void SetDefaults()
		{
			item.name = "Granite shield";
			item.toolTip = "Grants shadow dash below 50 HP. Recharges when above 150 HP";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 12, 0, 0);
			item.rare = 5;
			item.accessory = true;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife < 50 && Meme)
			{
				Meme = false;
				player.AddBuff(59, 220);
			}
			if (player.statLife > 150)
			{
				Meme = true;
			}
		}
	}
}
