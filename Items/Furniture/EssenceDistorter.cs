using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Furniture
{
    public class EssenceDistorter : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Essence Distorter";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.maxStack = 99;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 25;

            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("EssenceDistorter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence");
            recipe.AddIngredient(null, "TidalEssence");
            recipe.AddIngredient(null, "FieryEssence");
            recipe.AddIngredient(null, "IcyEssence");
            recipe.AddIngredient(null, "PrimevalEssence");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
