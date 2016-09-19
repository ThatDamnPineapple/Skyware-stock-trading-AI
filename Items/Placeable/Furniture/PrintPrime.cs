using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Placeable.Furniture
{
	public class PrintPrime : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Skeletron Prime Blueprint";
            item.width = 94;
			item.height = 62;
            item.toolTip = "Fore-Warned is Four-Armed.";
            item.value = 15000;
            item.rare = 6;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("PrimePrint");
		}
	}
}