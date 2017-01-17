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
            item.toolTip = "+3% melee damage";
            item.value = 11000;
            item.rare = 1;

            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ClatterboneBreasplate") && legs.type == mod.ItemType("ClatterboneLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Upon taking lethal damage, applies Sturdy buff granting invulnerability for 1 second. 10 minute cooldown";
            player.GetModPlayer<MyPlayer>(mod).clatterboneSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.03F;
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
