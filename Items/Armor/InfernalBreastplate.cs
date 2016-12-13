using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class InfernalBreastplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Infernal Breasplate";
            item.width = 28;
            item.height = 20;
            item.toolTip = "Increases maximum mana by 60.";
            item.rare = 5;

            item.defense = 10;
        }
            public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 60;
        }

    }
}
