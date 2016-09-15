using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RoguePants : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Rogue Greaves";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases Throwing Velocity");
            item.value = 10;
            item.rare = 2;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.05f;
        }
    }
}