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
            item.toolTip = "+3% melee damage";
            item.value = 100;
            item.rare = 1;

            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.03F;        
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HardenedCarpace", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
