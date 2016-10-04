using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class CoralHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Coral Hammer";
            item.width = 34;
            item.height = 34;
            item.value = 100;
            item.rare = 1;
            item.hammer = 39;
            item.damage = 7;
            item.knockBack = 5.5f;
            item.useStyle = 1;
            item.useTime = 21;
            item.useAnimation = 30;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 3);
            recipe.AddIngredient(ItemID.Seashell, 3);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
