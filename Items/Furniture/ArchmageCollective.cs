using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Furniture
{
    public class ArchmageCollective : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Archmage's Collective";
            item.width = 44;
            item.height = 64;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("ArchmageCollective");
        }
        /*public override void AddRecipes() //Commented out until i find the right ids
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome, 1); 
            recipe.AddIngredient(ItemID.SoulOfLight, 3); // 1 soul
            recipe.AddIngredient(ItemID.SoulOfNight, 3); // 2 soul
            recipe.AddIngredient(ItemID.SoulOfFright, 3); //red soul
            recipe.AddIngredient(ItemID.SoulOfMight, 3); // blue soul
            recipe.AddIngredient(ItemID.SoulOfSight, 3); // ayy lmao - Voxel
            recipe.AddIngredient(ItemID.Wood, 30);
            recipe.AnyWood = true;
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        */
    }
}