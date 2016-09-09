using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuskHood : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dusk Hood";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increased Magic Damage and Decreased Mana Usage.";
            item.value = 10000;
            item.rare = 6;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DuskPlate") && legs.type == mod.ItemType("DuskLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            
            player.setBonus = "15% Increased Magic and Ranged Damage at Night,but 0 Life Regen at Day ";            
            if (Main.dayTime)
            {
                player.lifeRegen = 0;
                player.lifeRegenCount = 0;
            }       
            else
            {
                player.rangedDamage += 0.15f;
                player.magicDamage += 0.15f;
            }                      
        }

        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.10f;
            player.magicDamage += 0.10f;
        }
        public virtual void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                npc.AddBuff(BuffID.ShadowFlame, 200, true);
            }            
        }
    }
}