using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class GraniteHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Granite Hammer";
            item.width = 44;
            item.height = 40;
            item.value = 8000;
            item.rare = 2;

            item.hammer = 80;

            item.damage = 20;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = 28;
            item.useAnimation = 28;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GraniteChunk", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}