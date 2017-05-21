using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class SpiritKey : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Soul Key";
            item.width = item.height = 16;
            AddTooltip("'Charged with the souls of aeons past'");
            item.rare = 0;
            item.maxStack = 99;
            item.value = 100;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 19;

            item.noMelee = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 12);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
