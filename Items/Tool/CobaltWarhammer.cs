using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class CobaltWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cobalt Warhammer";
            item.damage = 38;
            item.melee = true;
            item.width = 44;
            item.height = 40;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 80;
            item.useStyle = 1;
            item.knockBack = 5.5f;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}