using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Material.Artifact
{
    public class Catalyst : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Catalyst");
			Tooltip.SetDefault("'It seems to originate from Ancient Aliens'");
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }


        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.value = 500;
            item.rare = 10;
            item.maxStack = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 4);
            recipe.AddIngredient(ItemID.Ectoplasm, 6);
            recipe.AddIngredient(ItemID.FragmentSolar, 3);
            recipe.AddIngredient(null, "IcyEssence", 3);
            recipe.AddIngredient(null, "FieryEssence", 3);
            recipe.AddIngredient(null, "DuneEssence", 3);
            recipe.AddIngredient(null, "PrimevalEssence", 3);
            recipe.AddIngredient(null, "TidalEssence", 3);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.LunarTabletFragment, 4);
            recipe1.AddIngredient(ItemID.Ectoplasm, 6);
            recipe1.AddIngredient(ItemID.FragmentNebula, 3);
            recipe1.AddIngredient(null, "IcyEssence", 3);
            recipe1.AddIngredient(null, "FieryEssence", 3);
            recipe1.AddIngredient(null, "DuneEssence", 3);
            recipe1.AddIngredient(null, "PrimevalEssence", 3);
            recipe1.AddIngredient(null, "TidalEssence", 3);
            recipe1.AddTile(null, "CreationAltarTile");
            recipe1.SetResult(this, 1);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.LunarTabletFragment, 4);
            recipe2.AddIngredient(ItemID.Ectoplasm, 6);
            recipe2.AddIngredient(ItemID.FragmentStardust, 3);
            recipe2.AddIngredient(null, "IcyEssence", 3);
            recipe2.AddIngredient(null, "FieryEssence", 3);
            recipe2.AddIngredient(null, "DuneEssence", 3);
            recipe2.AddIngredient(null, "PrimevalEssence", 3);
            recipe2.AddIngredient(null, "TidalEssence", 3);
            recipe2.AddTile(null, "CreationAltarTile");
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ItemID.LunarTabletFragment, 4);
            recipe3.AddIngredient(ItemID.Ectoplasm, 6);
            recipe3.AddIngredient(ItemID.FragmentVortex, 3);
            recipe3.AddIngredient(null, "IcyEssence", 3);
            recipe3.AddIngredient(null, "FieryEssence", 3);
            recipe3.AddIngredient(null, "DuneEssence", 3);
            recipe3.AddIngredient(null, "PrimevalEssence", 3);
            recipe3.AddIngredient(null, "TidalEssence", 3);
            recipe3.AddTile(null, "CreationAltarTile");
            recipe3.SetResult(this, 1);
            recipe3.AddRecipe();
        }
    }
}