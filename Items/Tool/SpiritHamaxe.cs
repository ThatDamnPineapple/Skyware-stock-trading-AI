using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class SpiritHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Spirit Hamaxe";
            item.width = 44;
            item.height = 40;
            item.value = 20000;
            item.rare = 5;

            item.axe = 16;
            item.hammer = 110;

            item.damage = 35;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = 24;
            item.useAnimation = 24;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "SpiritBar", 15);
            modRecipe.AddTile(TileID.MythrilAnvil);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
    }
}
