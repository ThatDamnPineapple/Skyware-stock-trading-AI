using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RunicGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Runic Greaves";
            item.width = 34;
            item.height = 30;
            AddTooltip("Decreased Mana Cost and Doubles time of invincibility after Getting hit");
            item.value = 10;
            item.rare = 8;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.15f;
            player.immuneTime *= 2;


        }        
    }
}