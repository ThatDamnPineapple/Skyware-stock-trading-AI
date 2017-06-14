using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class LihzahrdLegs : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrd Leggings");
			Tooltip.SetDefault("Increased thrown damage by 11%");
		}

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 100000;
            item.rare = 7;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player)
        {
			player.thrownDamage += 0.11f;
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2766, 14);
            recipe.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}