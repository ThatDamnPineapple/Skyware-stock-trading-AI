using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class BloodKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Blood Dagger";
            item.useStyle = 1;
            item.width = 14;
            item.height = 50;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("BloodKnife");
            item.useAnimation = 20;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 20;
            item.shootSpeed = 12f;
            item.damage = 11;
            item.knockBack = 2.7f;
			item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodFire", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}
