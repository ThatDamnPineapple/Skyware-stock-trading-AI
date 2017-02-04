using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Accessory
{
	public class EternityCharm : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Eternity Charm";
			item.width = 18;
            item.expert = true;
            item.height = 18;
			item.toolTip = "You are the champion of Spirits \n Launches a multitude of Soul Shards when damaged";
			item.value = Item.buyPrice(0, 22, 0, 0);
            item.rare = 11;
			item.accessory = true;
		}
        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(7, 8);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<MyPlayer>(mod).OverseerCharm = true;
        }

	}
}
