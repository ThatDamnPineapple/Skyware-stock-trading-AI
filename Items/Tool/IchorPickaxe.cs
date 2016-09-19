using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class IchorPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ichor Pickaxe";
            item.width = 32;
            item.height = 32;
            item.value = 10000;
            item.rare = 4;

            item.pick = 160;

            item.damage = 18;
            item.knockBack = 6;

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
            recipe.AddIngredient(ItemID.Ichor, 5);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}