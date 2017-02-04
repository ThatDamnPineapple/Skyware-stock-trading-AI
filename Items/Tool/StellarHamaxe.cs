using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class StellarHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stellar Hamaxe";
            item.width = 50;
            item.height = 44;
            item.value = 10000;
            item.rare = 4;

            item.axe = 32;
            item.hammer = 100;

            item.damage = 11;
            item.knockBack = 6;

            item.useStyle = 1;
            item.useTime = 16;
            item.useAnimation = 24;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}