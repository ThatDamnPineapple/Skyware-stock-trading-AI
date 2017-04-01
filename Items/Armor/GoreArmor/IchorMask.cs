using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GoreArmor
{
    public class IchorMask : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Gore Mask";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases melee damage by 7% and melee critical strike chance by 6%";
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.rare = 4;

            item.defense = 11;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("IchorPlate") && legs.type == mod.ItemType("IchorLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Press the 'Ichor Rage' hotkey to cause damage all nearby enemies and suffer Ichor for a long period of time \n 1 minute cooldown";
            player.GetModPlayer<MyPlayer>(mod).ichorSet1 = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.07f;

            player.meleeCrit += 6;
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
