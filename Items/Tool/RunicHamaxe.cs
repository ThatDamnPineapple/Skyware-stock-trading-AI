using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class RunicHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Runic Hamaxe";
            item.damage = 30;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 24;
            item.useAnimation = 24;
            item.axe = 16;
            item.hammer = 110;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 4;
            item.crit = 0;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}