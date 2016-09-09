using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class GraniteShield : ModItem
	{
		private bool Meme;
		public override void SetDefaults()
		{
			item.name = "Granite shield";
			item.toolTip = "Gives shadow dash below 50 HP. Recharges above 150";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
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
