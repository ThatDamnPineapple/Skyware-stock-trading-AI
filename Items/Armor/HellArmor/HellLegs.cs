using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.HellArmor
{
    public class  HellLegs : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Malevolent Greaves";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Reduces ammo consumption by 25 \n Increases movement speed by 10%";
            item.value = 46000;
            item.rare = 6;
            item.defense = 15;
        }
        public override void UpdateEquip(Player player)
        {
            player.ammoCost75 = true;
            player.moveSpeed += 0.1f;

        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FieryEssence", 18);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}