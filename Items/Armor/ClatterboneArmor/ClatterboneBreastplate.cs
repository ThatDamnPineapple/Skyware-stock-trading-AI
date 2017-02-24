using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ClatterboneArmor
{
    public class ClatterboneBreastplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Clatterbone Breastplate";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increases melee damage by 4%";
            item.value = 6000;
            item.rare = 2;

            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.04F;        
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
