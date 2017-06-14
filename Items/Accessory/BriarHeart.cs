using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class BriarHeart : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Briar Heart");
            Tooltip.SetDefault("Increases melee damage by 4% and melee speed by 3%\nIncreases melee critical srike chance by 9% and ranged critical strike chance by 7%\nIncreases magic and thrown critical strike chance by 5% and maximum life by 10\nMagic attacks may burn enemies\nGetting hurt may trigger 'Poison Bite,' causing all attacks to inflict poison for a short while\nIncreases maximum mana by 40 when under half health");

        }


        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 42;
            item.value = Item.buyPrice(0, 1, 20, 0);
            item.rare = 6;
            item.defense = 3;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 5;
            player.meleeCrit += 9;
            player.thrownCrit += 5;
            player.rangedCrit += 7;
            player.meleeDamage += 0.04f;
            player.statLifeMax2 += 10;
            player.meleeSpeed += 0.03f;
            player.GetModPlayer<MyPlayer>(mod).shamanBand = true;
            player.GetModPlayer<MyPlayer>(mod).gremlinTooth = true;
            {
                if (player.statLife <= player.statLifeMax2 / 2)
                {
                    player.statManaMax2 += 60;
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneCharm", 1);
            recipe.AddIngredient(null, "HuntingNecklace", 1);
            recipe.AddIngredient(null, "ShamanBand", 1);
            recipe.AddIngredient(null, "GremlinTooth", 1);
            recipe.AddIngredient(null, "Acid", 4);
            recipe.AddIngredient(null, "PutridPiece", 5);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "BoneCharm", 1);
            recipe2.AddIngredient(null, "HuntingNecklace", 1);
            recipe2.AddIngredient(null, "ShamanBand", 1);
            recipe2.AddIngredient(null, "GremlinTooth", 1);
            recipe2.AddIngredient(null, "Acid", 4);
            recipe2.AddIngredient(null, "FleshClump", 5);
            recipe2.AddIngredient(ItemID.SoulofNight, 8);
            recipe2.AddIngredient(ItemID.SoulofLight, 8);
            recipe2.AddTile(TileID.TinkerersWorkbench);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
