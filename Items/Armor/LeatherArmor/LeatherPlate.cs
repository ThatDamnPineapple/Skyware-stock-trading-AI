using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.LeatherArmor
{
    public class LeatherPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Leather Plate";
            item.width = 30;
            item.height = 18;
            item.toolTip = "Increases ranged critical strike chance by 3%";
            item.value = 2000;
            item.rare = 1;

            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 3;        
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
