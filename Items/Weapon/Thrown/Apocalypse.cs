using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class Apocalypse : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Apocalypse";
            item.width = item.height = 42;
            item.rare = 4;
            item.maxStack = 999;

            item.crit = 11;
            item.damage = 65;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 13;

            item.melee = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("ApocalypseProj");
            item.shootSpeed = 11;

            item.useSound = 1;
        }

       public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"CursedFire", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 33);
            recipe.AddRecipe();
        }
    }
}
