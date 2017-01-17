using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class TitanicCrusher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Titanic Crusher";
            item.width = 30;
            item.height = 10;
            item.toolTip = "???";
            item.value = Item.sellPrice(0, 7, 43, 0);
            item.rare = 7;
            item.crit = 8;
            item.damage = 66;
            item.knockBack = 8;
            item.useStyle = 5;
            item.useTime = item.useAnimation = 32;   
            item.scale = 1.1F;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("TitanicCrusher");
            item.shootSpeed = 12.5F;
            item.UseSound = SoundID.Item1;   
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TidalEssence", 14);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}