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
            item.value = 4100;
            item.rare = 2;
            item.hammer = 56;
            item.damage = 20;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 25;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
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
