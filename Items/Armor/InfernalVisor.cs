using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class InfernalVisor : ModItem
    {
        int timer;
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Infernal Visor";
            item.width = 28;
            item.height = 20;
            item.toolTip = "Increases magic damage by 14% and magic critical strike chance by 8%.";
            item.rare = 5;

            item.defense = 9;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 8;
            player.magicDamage += 0.14f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("InfernalBreastplate") && legs.type == mod.ItemType("InfernalGreaves");
        }

        public override void UpdateArmorSet(Player player)
        {
            timer++;

            if (timer == 20)
            {
                int dust = Dust.NewDust(player.position, player.width, player.height, 6);
                timer = 0;
            }
            {
                player.setBonus = "Infernal Guardians surround you when under 25% of your life.";
                player.GetModPlayer<MyPlayer>(mod).infernalSet = true;

            }
        }
    }
}
