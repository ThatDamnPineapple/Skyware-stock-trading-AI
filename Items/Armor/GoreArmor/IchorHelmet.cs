using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GoreArmor
{
    public class IchorHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ichor Helm";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases melee speed by 7% and reduces damage taken by 7%";
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;

            item.defense = 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("IchorPlate") && legs.type == mod.ItemType("IchorLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Press the 'Ichor Guard' to spawn six homing ichor clumps that sap enemy life";
            player.GetModPlayer<MyPlayer>(mod).ichorSet2 = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.07f;

            player.endurance += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
