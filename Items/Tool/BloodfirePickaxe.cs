using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class BloodfirePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bloodfire Pickaxe";
            item.width = 38;
            item.height = 30;
            item.value = 100;
            item.rare = 1;
            item.pick = 50;
            item.damage = 10;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 20;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"BloodFire", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
