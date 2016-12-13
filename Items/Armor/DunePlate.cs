using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DunePlate : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dune Plate";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases Throwing Velocity by 16% and Thrown Crit by 8%";
            item.value = 6000;
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