using System.Collections.Generic;
using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FPlate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floran Plate");
            Tooltip.SetDefault("+5% increased magic damage and 20 more maximum mana");

        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 18;
            item.value = Terraria.Item.sellPrice(0, 0, 13, 0);
            item.rare = 2;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.magicDamage *= 1.05f; //20 max mana
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 14);   //you need 10 Wood
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}