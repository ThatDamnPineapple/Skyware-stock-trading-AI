using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PaladinChestguard : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Paladin Chestguard";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increased Thrown Damage and Velocity.");
            AddTooltip("33% Chance to not Consume throwed Item");
            item.value = 100000;
            item.rare = 8;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage = 1.5f;
            player.thrownVelocity = 1.3f;
            player.thrownCost33 = true;
        }
    }
}