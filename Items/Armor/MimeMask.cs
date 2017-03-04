using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class MimeMask : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Mime Mask";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases summon damage by 3%");
            item.value = 3000;
            item.rare = 1;
            item.defense = 3;
        }
         public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.03f;
        }
    }
}
