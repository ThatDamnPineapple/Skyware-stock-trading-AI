using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GoreArmor
{
    public class IchorLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ichor Leggings";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases movement speed by 10% and melee critical strike chance by 8%";
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;

            item.defense = 11;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 8;

            player.moveSpeed += 0.1f; ;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
