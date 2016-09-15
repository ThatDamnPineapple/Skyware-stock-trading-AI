using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class MythrilWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mythril Warhammer";
            item.damage = 44;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 30;
            item.useAnimation = 30;
            item.hammer = 83;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}