using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class StardropStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stardrop Staff";
            item.damage = 11;
            item.magic = true;
            item.mana = 8;
            item.width = 36;
            item.height = 36;
            item.toolTip = "Shoots a splitting ball of water";
            item.useTime = 52;
            item.useAnimation = 52;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 1200;
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("StardropStaffProj");
            item.shootSpeed = 14f;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 6);
            recipe.AddIngredient(ItemID.Starfish, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
