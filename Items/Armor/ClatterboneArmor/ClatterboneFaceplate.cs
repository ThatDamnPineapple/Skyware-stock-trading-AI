using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ClatterboneArmor
{
    public class ClatterboneFaceplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Clatterbone Faceplate";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases melee damage by 6%";
            item.value = 11000;
            item.rare = 1;

            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ClatterboneBreastplate") && legs.type == mod.ItemType("ClatterboneLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Upon taking lethal damage, the amount of damage taken is returned to you. 6 minute cooldown";
            player.GetModPlayer<MyPlayer>(mod).clatterboneSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.05F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
