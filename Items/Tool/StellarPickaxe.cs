using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class StellarPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stellar Pickaxe";
            item.width = 36;
            item.height = 36;
            item.value = 1000;
            item.rare = 4;

            item.pick = 150;

            item.damage = 21;
            item.knockBack = 3;

            item.useStyle = 1;
            item.useTime = 11;
            item.useAnimation = 25;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}