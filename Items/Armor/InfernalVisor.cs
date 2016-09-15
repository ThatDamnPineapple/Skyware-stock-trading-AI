using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class InfernalVisor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Infernal Visor";
            item.width = 28;
            item.height = 20;
            item.toolTip = "???";
            item.rare = 5;

            item.defense = 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("InfernalBreastplate") && legs.type == mod.ItemType("InfernalGreaves");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<MyPlayer>(mod).infernalSet = true;
        }
    }
}
