using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class PestilentPummeler : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Pestilent Pummeler";
            item.damage = 57;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 8;
            item.useAnimation = 29;
            item.hammer = 90;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}