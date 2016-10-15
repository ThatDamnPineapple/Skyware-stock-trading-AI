using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class MoltenBlades : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Molten Blades";
            item.width = 34;
            item.height = 30;
            item.toolTip = "50% Chance to Inflict Fire";
            item.shoot = mod.ProjectileType("MoltenBladesProjectile");
            item.useAnimation = 18;
            item.useTime = 18;
            item.shootSpeed = 10f;
            item.damage = 27;
            item.knockBack = 0f;
            item.value = Item.buyPrice(0, 0, 0, 80);
            item.crit = 5;
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
