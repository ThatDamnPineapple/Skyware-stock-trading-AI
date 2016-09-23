using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.BloomwindArmor
{
    public class BloomwindChestguard : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bloomwind Chestguard";
            item.width = 34;
            item.height = 30;
            item.toolTip = "+1 minion slot and +15% minion damage";
            item.value = 10000;
            item.rare = 6;

            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.15F;
        }
    }
}