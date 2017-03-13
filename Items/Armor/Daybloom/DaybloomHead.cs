using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.Daybloom
{
    public class DaybloomHead : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Daybloom Helm";
            item.width = 28;
            item.height = 24;
            item.toolTip = "Increases maximum mana by 20";
            item.value = 000;
            item.rare = 0;
            item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DaybloomBody") && legs.type == mod.ItemType("DaybloomLegs");
        }
        public override void UpdateArmorSet(Player player)
        {

            player.setBonus = "Increases your magic damage and critical strike chance when the Sun flows through you";

            if (Main.dayTime)
            {
                player.magicDamage += 0.03f;
                player.magicCrit += 3;

                if (Main.rand.Next(6) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 152);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Daybloom, 1);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
