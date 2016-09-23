using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.TitanicArmor
{
    public class TitanicPlatemail : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Titanic Platemail";
            item.width = 28;
            item.height = 22;
            item.toolTip = "+13% melee damage and +10% melee speed";
            item.value = 10000;
            item.rare = 5;

            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.13F;
            player.meleeSpeed += 0.1F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TidalEssence", 20);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
