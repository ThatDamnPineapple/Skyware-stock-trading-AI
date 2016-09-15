using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class StellarPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stellar Pickaxe";
            item.damage = 11;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 11;
            item.useAnimation = 25;
            item.pick = 34;               
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}