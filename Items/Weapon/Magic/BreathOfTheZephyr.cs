using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BreathOfTheZephyr : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Breath of the Zephyr"; 
            item.damage = 19;
            item.magic = true;
            item.mana = 13;
            item.width = 46;
            item.height = 46;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 1;
            item.UseSound = SoundID.Item34;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Zephyr");
            item.shootSpeed = 26f;
            item.toolTip = "Creats a mighty gust of wind to damage your foes";
            item.autoReuse = false;
        }


      public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud, 15);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddIngredient(ItemID.Feather, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
