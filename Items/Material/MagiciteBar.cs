using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class MagiciteBar : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magicite Bar";
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            AddTooltip("It is warm with pure manic energy");
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 50;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagiciteOreItem", 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}