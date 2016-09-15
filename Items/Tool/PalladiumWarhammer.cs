using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class PalladiumWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Palladium Warhammer";
            item.damage = 41;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 83;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}