using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Geode : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Geode";
            item.width = 24;
            item.height = 28;
            item.maxStack = 999;
            AddTooltip("'Shinnnnnnnnnyyyyy'");
            item.value = 100;
            item.rare = 4;
        }
public override void AddRecipes() 
{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
}