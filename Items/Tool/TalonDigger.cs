using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class TalonDigger : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Talon Digger";
            item.width = 36;
            item.height = 36;
            item.value = 1000;
            item.rare = 4;

            item.pick = 90;

            item.damage = 14;
            item.knockBack = 3;

            item.useStyle = 1;
            item.useTime = 16;
            item.useAnimation = 16;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Talon", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}