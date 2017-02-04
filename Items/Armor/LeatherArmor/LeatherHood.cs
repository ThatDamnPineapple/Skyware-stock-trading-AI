using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.LeatherArmor
{
    public class LeatherHood : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Leather Hood";
            item.width = 22;
            item.height = 12;
            item.toolTip = "Increases ranged damage by 3%";
            item.value = 100;
            item.rare = 1;

            item.defense = 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LeatherPlate") && legs.type == mod.ItemType("LeatherBoots");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases ranged damage by 6%";
            player.rangedDamage += 0.06F;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.03F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
