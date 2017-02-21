using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GoreArmor
{
    public class IchorPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ichor Platemail";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases melee damage by 10% and melee speed by 8%";
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 5;

            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;

            player.meleeSpeed += 0.08f; ;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
