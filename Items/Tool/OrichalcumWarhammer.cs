using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class OrichalcumWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Orichalcum Warhammer";
            item.damage = 47;
            item.melee = true;
            item.width = 42;
            item.height = 46;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 85;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}