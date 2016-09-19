using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Placeable.Furniture
{
    public class ArchmageCollective : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Archmage's Collective";
            item.width = 44;
            item.height = 64;

            item.maxStack = 99;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("ArchmageCollective");
        }

        public override void AddRecipes() //Commented out until i find the right ids
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome, 1); 
            recipe.AddIngredient(ItemID.SoulofLight, 3); // 1 soul
            recipe.AddIngredient(ItemID.SoulofNight, 3); // 2 soul
            recipe.AddIngredient(ItemID.SoulofFright, 3); //red soul
            recipe.AddIngredient(ItemID.SoulofMight, 3); // blue soul
            recipe.AddIngredient(ItemID.SoulofSight, 3); // ayy lmao - Voxel
            recipe.AddIngredient(ItemID.Wood, 30);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }        
    }
}