using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
    public class MoonGauntlet : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Gauntlet of the Moon";
            item.width = 16;
			item.height = 16;
            item.toolTip = "Increases melee damage by 15% and melee speed by 10% \n Attacks occasionally inflict Ichor, Cursed Inferno, and Daybroken \n Melee Attacks grant you Onyx Whirlwind, which increases movement speed \n ~Donator Item~ \n 'Infused with the Spirit of Meemourne'";
            item.rare = 11;
            item.value = 550000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 0.10f;
            player.meleeDamage += 0.15f;
            player.GetModPlayer<MyPlayer>(mod).moonGauntlet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 5);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(mod.ItemType("SolarEmblem"), 1);
            recipe.AddIngredient(mod.ItemType("EternityEssence"), 5);
            recipe.AddIngredient(mod.ItemType("ShadowGauntlet"), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Ichor, 50);
            recipe2.AddIngredient(ItemID.AncientBattleArmorMaterial, 5);
            recipe2.AddIngredient(mod.ItemType("SolarEmblem"), 1);
            recipe2.AddIngredient(mod.ItemType("EternityEssence"), 5);
            recipe2.AddIngredient(mod.ItemType("ShadowGauntlet"), 1);
            recipe2.AddTile(TileID.TinkerersWorkbench);
            recipe2.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
