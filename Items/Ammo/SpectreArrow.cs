using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class SpectreArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ghast Arrow";
			item.width = 10;
			item.height = 28;
            item.rare = 9;
            item.value = 1000;

            item.maxStack = 999;

            item.damage = 14;
			item.knockBack = 2f;
            item.ammo = 1;

			item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("SpectreArrow");
            item.shootSpeed = 1f;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
		}
	}
}
