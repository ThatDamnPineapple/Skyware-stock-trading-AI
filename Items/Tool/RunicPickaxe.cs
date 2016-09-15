using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class RunicPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Runic Pickaxe";
            item.damage = 18;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 7;
            item.useAnimation = 25;
            item.pick = 190;               
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
            recipe.AddIngredient(null, "Rune", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}