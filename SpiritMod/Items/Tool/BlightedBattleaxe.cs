using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class BlightedBattleaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Blighted Battleaxe";
            item.damage = 53;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 8;
            item.useAnimation = 29;
            item.axe = 13;
            item.useStyle = 1;
            item.knockBack = 5;
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
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}