using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory.Artifact
{
    public class DarkBough : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bough of Corruption");
            Tooltip.SetDefault("'The voices within offer me wicked magics'\nMinion attacks on foes have a 10% chance to release multiple Nightmare Bolts in different directions\nMinions have an extremely low chance to return damage dealt as health\nIncreases summoning damage by 10%\n~Artifact Accessory~");
        }


        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.rare = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.1f;
            player.GetModPlayer<MyPlayer>(mod).DarkBough = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostLotus", 1);
            recipe.AddIngredient(null, "ChaosEmber", 1);
            recipe.AddIngredient(null, "FireLamp", 1);
            recipe.AddIngredient(ItemID.SummonerEmblem, 1);
            recipe.AddIngredient(null, "SpiritBar", 5);
            recipe.AddIngredient(null, "PrimordialMagic", 50);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
