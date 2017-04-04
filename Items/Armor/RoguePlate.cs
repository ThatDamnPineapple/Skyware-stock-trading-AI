using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RoguePlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Rogue Plate";
            item.width = 30;
            item.height = 18;
            AddTooltip("Increases throwing damage by 4%");
            item.value = Terraria.Item.buyPrice(0, 0, 20, 0);
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.04f;
        }
    }
}