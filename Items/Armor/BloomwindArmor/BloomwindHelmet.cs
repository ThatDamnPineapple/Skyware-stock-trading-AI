using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.BloomwindArmor
{
    public class BloomwindHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bloomwind Helmet";
            item.width = 40;
            item.height = 30;
            item.toolTip = "+3 minion slots and +10% minion damage";
            item.value = 10000;
            item.rare = 6;

            item.defense = 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BloomwindChestguard") && legs.type == mod.ItemType("BloomwindLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are protected by a guardian of the wild";
            player.GetModPlayer<MyPlayer>(mod).bloomwindSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 3;
            player.minionDamage += 0.10f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PrimevalEssence", 8);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}