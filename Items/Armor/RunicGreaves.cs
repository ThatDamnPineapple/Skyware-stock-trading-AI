using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{

    [AutoloadEquip(EquipType.Legs)]
    public class RunicGreaves : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Greaves");
            Tooltip.SetDefault("Reduces mana cost by 11% and Increases immmunity frames.");

        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.value = 60000;
            item.rare = 5;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.11f;
            player.immuneTime *= 2;


        }    
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 10);
            recipe.AddIngredient(null, "SoulShred", 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}