using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
    public class TheCouch : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Couch");
			Tooltip.SetDefault("Increases defense, but reduces speed when near.\n ~Donator Item~");
		}


        public override void SetDefaults()
		{
            item.width = 64;
			item.height = 34;
            item.value = 50000;

            item.maxStack = 99;
			item.rare = 4;
            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("TheCouch");
		}

    }
}