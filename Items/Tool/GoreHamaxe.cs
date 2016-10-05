using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class GoreHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Gore Hamaxe";
            item.width = 60;
            item.height = 60;
            item.value = 10000;
            item.rare = 4;
			  item.hammer = 45;
            item.axe = 13;

            item.damage = 27;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = 8;
            item.useAnimation = 29;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}