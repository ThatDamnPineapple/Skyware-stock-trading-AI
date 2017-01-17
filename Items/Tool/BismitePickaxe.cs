using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class BismitePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bismite Pickaxe";
            item.width = 38;
            item.height = 30;
            item.value = 1000;
            item.rare = 2;
            item.pick = 35;
            item.damage = 4;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 18;
            item.useAnimation = 23;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"BismiteCrystal", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
