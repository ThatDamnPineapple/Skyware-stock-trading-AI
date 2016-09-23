using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.TitanicArmor
{
    public class TitanicGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Titanic Greaves";
            item.width = 28;
            item.height = 22;
            item.toolTip = "+5% melee crit chance and +10% move speed";
            item.value = 10000;
            item.rare = 5;

            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 5;
            player.moveSpeed += 0.1F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TidalEssence", 18);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
