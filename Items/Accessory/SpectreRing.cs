using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class SpectreRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spectre Ring";
			item.width = 18;
			item.height = 18;
            item.toolTip = "When hurt, you shoot a bolt of Spiritual Energy to protect yourself!";
            item.value = Item.buyPrice(0, 15, 0, 0);
			item.rare = 9;

			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>(mod).SRingOn = true;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
