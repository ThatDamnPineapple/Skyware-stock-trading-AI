using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class MartianGrenade : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.name = "Electrosphere Grenade";
            item.shoot = mod.ProjectileType("Grenadeproj");
            item.useAnimation = 30;
            item.rare = 8;
            item.toolTip = "'WARNING- HIGH VOLTAGE. DANGEROUS FOR USER'";
            item.useTime = 34;
            item.damage = 110;
        }

        public override void AddRecipes()
        {
            ModRecipe rcp = new ModRecipe(mod);
            rcp.AddIngredient(null, "MartianCore", 1);
            rcp.AddTile(TileID.MythrilAnvil);
            rcp.SetResult(this, 20);
            rcp.AddRecipe();

        }
    }
}