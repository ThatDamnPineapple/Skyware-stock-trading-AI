using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class CoilSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "CoilSpear";
            item.useStyle = 1;
            item.width = 14;
            item.height = 50;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CoilSpearProj");
            item.useAnimation = 26;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 26;
            item.shootSpeed = 9f;
            item.damage = 23;
            item.knockBack = 2.7f;
			item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.autoReuse = false;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TechDrive", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}
