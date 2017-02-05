using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Magic
{
    public class FrostTome : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frost Tome";
            item.width = item.height = 26;
            item.toolTip = "Fires homing snowflakes at foes!";
            item.crit = 4;
            item.mana = 6;
            item.damage = 45;
            item.knockBack = 0;
            item.useStyle = 5;
            item.useTime = item.useAnimation = 23;
            item.magic = true;
            item.useTurn = true;
			item.value = 123000;
			item.rare = 6;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrostFlake");
            item.shootSpeed = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IcyEssence", 14);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}