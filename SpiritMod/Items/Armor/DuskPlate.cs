using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuskPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dusk Plate";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increased Ranged Damage.");
            AddTooltip("25% Chance to not Consume Arrows");
            item.value = 10000;
            item.rare = 6;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage = 1.12f;
            player.ammoCost75 = true;
        }
    }
}