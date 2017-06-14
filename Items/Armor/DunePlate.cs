using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DunePlate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Plate");
			Tooltip.SetDefault("Increases Throwing Velocity by 16% and Thrown Crit by 8%");
		}


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 18;
            item.value = 66000;
            item.rare = 6;
            item.defense = 17;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownCrit+= 8;
            player.thrownVelocity += 0.16f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence", 20);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}