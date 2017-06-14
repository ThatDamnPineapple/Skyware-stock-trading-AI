using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class MartianArrow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrified Arrow");
            Tooltip.SetDefault("'Positively negative for enmeies!'");
        }
        public override void SetDefaults()
        {
            item.width = 14;
			item.height = 30;
			item.value = 12000;
            item.rare = 9;

            item.maxStack = 999;

            item.damage = 16;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("ElectricArrow");
            item.shootSpeed = 1f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MartianCore");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
		}
	}
}
