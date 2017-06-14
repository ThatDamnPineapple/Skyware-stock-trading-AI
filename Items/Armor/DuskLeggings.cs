using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DuskLeggings : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dusk Leggings");
            Tooltip.SetDefault("Increases critical strike chance by 12%");

        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.value = 40000;
            item.rare = 5;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit = 12;
            player.rangedCrit = 12;
            player.meleeCrit = 12;
            player.thrownCrit = 12;
        }       
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuskStone", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}