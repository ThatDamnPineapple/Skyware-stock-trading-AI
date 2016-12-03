using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class BloodfireHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bloodfire Hammer";
            item.width = 38;
            item.height = 30;
            item.value = 100;
            item.rare = 1;
            item.hammer = 50;
            item.damage = 10;
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
            recipe.AddIngredient(null,"BloodFire", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
