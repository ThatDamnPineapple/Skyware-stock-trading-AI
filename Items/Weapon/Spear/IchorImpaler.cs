using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear {
public class IchorImpaler : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Gore Impaler";
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.melee = true;
        item.noMelee = true;
        item.toolTip = "Hit foes course with ichor"; 
        item.useAnimation = 40;
        item.useTime = 40;
        item.shootSpeed = 6f;
        item.knockBack = 7f;
        item.damage = 50;
        item.value = Item.sellPrice(0, 1, 60, 0);
        item.rare = 5;
        item.shoot = mod.ProjectileType("IchorImpalerProj");
    }
    
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
