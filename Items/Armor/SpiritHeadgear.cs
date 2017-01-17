using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class SpiritHeadgear : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Spirit Headgear";
            item.width = 40;
            item.height = 40;
            item.toolTip = "+5 Max Life and 12% Increased Melee Damage";
            item.value = 40000;
            item.rare = 5;
            item.defense = 14;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("SpiritBodyArmor") && legs.type == mod.ItemType("SpiritLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Damage taken Reduced by 20% but Decreased Movement Speed";
            //Code actual effect
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.meleeDamage += 0.12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}