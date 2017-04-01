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
            item.name = "Gore Leggings";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases movement speed by 10% and melee critical strike chance by 6%";
            item.value = Item.sellPrice(0, 0, 90, 0);
            item.rare = 4;

            item.defense = 9;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 6;

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
