using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class Flor : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Floran Dagger";
            item.useStyle = 1;
            item.width = 32;
            item.height = 18;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("FlorP");
            item.useAnimation = 13;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 27;
            item.shootSpeed = 7f;
            item.damage = 12;
            item.knockBack = 1.5f;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 2;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}