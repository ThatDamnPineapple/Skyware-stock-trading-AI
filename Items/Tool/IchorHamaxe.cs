using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class IchorHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ichor Hamaxe";
            item.damage = 32;
            item.melee = true;
            item.width = 44;
            item.height = 38;
            item.useTime = 25;
            item.useAnimation = 25;
            item.axe = 20;
            item.hammer = 90;
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
            recipe.AddIngredient(ItemID.Ichor, 5);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}