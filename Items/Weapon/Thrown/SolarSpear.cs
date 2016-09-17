using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class SolarSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Solar Spear";
            item.useStyle = 1;
            item.width = 22;
            item.height = 22;
			 item.autoReuse = true;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("SolarSpear");
            item.useAnimation = 29;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 29;
            item.shootSpeed = 8.0f;
            item.damage = 88;
            item.knockBack = 3f;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3458, 1);
            recipe.AddTile(412);
            recipe.SetResult(this, 111);
            recipe.AddRecipe();
        }
    }
}
