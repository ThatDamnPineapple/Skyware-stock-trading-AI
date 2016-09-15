using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class InfernalGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Infernal Greaves";
            item.width = 28;
            item.height = 20;
            item.toolTip = "???";
            item.rare = 5;

            item.defense = 5;
        }
    }
}
