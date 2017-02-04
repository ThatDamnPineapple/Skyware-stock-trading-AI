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
            item.toolTip = "Increases magic damage by 10% and reduces mana cost by 10%";
            item.value = 70000;
            item.rare = 5;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DuskPlate") && legs.type == mod.ItemType("DuskLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            
            player.setBonus = "8% Increased Magic and Ranged Damage at Night \n You are surrounded by a rune that guides the way \n Magic attacks inflict Shadowflame ";
            {
                player.GetModPlayer<MyPlayer>(mod).duskSet = true;
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
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuskStone", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}