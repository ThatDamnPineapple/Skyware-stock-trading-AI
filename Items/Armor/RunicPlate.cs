using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RunicPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Runic Plate";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increased Magic Crit and Movement Speed.");
            item.value = 10;
            item.rare = 8;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 1.10f;
            player.magicCrit += 10;
        }
    }
}