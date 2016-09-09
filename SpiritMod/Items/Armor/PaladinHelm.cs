using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PaladinHelm : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Paladin Helm";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increased Thrown Damage and Velocity.";
            item.value = 10000;
            item.rare = 8;
            item.defense = 20;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PaladinChestguard") && legs.type == mod.ItemType("PaladinGreaves");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Damage taken Reduced by 20% but Decreased Movement Speed";
            player.endurance = 0.2f;
            player.moveSpeed = 0.8f;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage = 1.7f;
            player.thrownVelocity = 1.2f;
        }
    }
}