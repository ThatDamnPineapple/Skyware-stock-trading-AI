using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class CoralAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Coral Axe";
            item.width = 38;
            item.height = 30;
            item.value = 100;
            item.rare = 1;
            item.axe = 8;
            item.damage = 6;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 25;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 3);
            recipe.AddIngredient(ItemID.Seashell, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
