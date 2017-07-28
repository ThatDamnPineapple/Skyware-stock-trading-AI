using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.AcidArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AcidBody : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acid Plate");
            Tooltip.SetDefault("Increases throwing damage by 15%");

        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 6000;
            item.rare = 5;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Acid", 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
