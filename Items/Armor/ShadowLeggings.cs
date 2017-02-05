using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class ShadowLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Possessed Leggings";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases movement speed by 10% and melee damage by 4%");
            item.value = 30000;
            item.rare = 4;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.meleeDamage += 0.04f;
        }
    }
}