using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class AmbertuskSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ambertusk Spear";
            item.width = item.height = 42;
            item.toolTip = "???";
            item.rare = 4;
            item.maxStack = 999;

            item.crit = 10;
            item.damage = 60;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 35;

            item.melee = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("AmbertuskSpear");
            item.shootSpeed = 10;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence", 5);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
