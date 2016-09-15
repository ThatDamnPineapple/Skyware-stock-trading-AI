using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PaladinGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Paladin Greaves";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increased Thrown Damage");
            item.value = 10;
            item.rare = 8;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage = 1.6f;
        }        
    }
}