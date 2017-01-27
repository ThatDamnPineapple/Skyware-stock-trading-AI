using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Magic
{
    public class BloodfireStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bloodfire Staff";
            item.width = 28;
            item.height = 28;
            item.value = 10000;
            item.rare = 2;
            item.crit = 4;
            item.mana = 9;
            item.damage = 17;
            item.knockBack = 3;
            item.useStyle = 5;
            item.useTime = 32;
            item.useAnimation = 32;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            Item.staff[item.type] = true;
            item.shoot = mod.ProjectileType("BloodClump");
            item.shootSpeed = 8f;
            item.UseSound = SoundID.Item20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodFire", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}