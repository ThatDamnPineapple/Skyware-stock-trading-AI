using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class TitaniumWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Titanium Warhammer";
            item.damage = 50;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 89;
            item.useStyle = 1;
            item.knockBack = 8.5f;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}