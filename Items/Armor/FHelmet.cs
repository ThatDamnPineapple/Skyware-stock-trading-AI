using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class FHelmet : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Floran Helmet";
            item.width = 24;
            item.height = 22;
            item.toolTip = "5% Increased Magic Damage and Crit Chance";
            item.toolTip2 = "It's natural, yet seems to be from somwhere else...";
            item.value = 10000;
            item.rare = 3;
            item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 5;
            player.magicDamage += 0.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FPlate") && legs.type == mod.ItemType("FLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
            timer++;

            if (timer == 20)
            {
                int dust = Dust.NewDust(player.position, player.width, player.height, 44);
                timer = 0;
            }

            player.setBonus = "Florrrann Sssstab- 5% Increased Damage";
            player.meleeDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;


        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 12);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
