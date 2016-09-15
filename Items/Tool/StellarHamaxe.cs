using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class StellarHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stellar Hamaxe";
            item.damage = 11;
            item.melee = true;
            item.width = 50;
            item.height = 44;
            item.useTime = 16;
            item.useAnimation = 24;
            item.axe = 32;
            item.hammer = 18;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 4;
            item.crit = 0;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}