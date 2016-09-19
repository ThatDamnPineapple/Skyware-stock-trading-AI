using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	public class MarsBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Electrified Bullet";
			item.width = 8;
			item.height = 16;
            item.toolTip = "All Charged up!";
            item.value = 1000;
            item.rare = 8;

            item.maxStack = 999;

            item.damage = 13;
			item.knockBack = 1.5f;
            item.ammo = ProjectileID.Bullet;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("MarsBulletProj");
			item.shootSpeed = 16f;

		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MartianCore");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
	}
}