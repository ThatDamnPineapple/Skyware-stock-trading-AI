using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.IceArmor
{
    public class  IceHood : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Blizzard Hood";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases Magic Damage by 15% and increases maximum mana by 40";
            item.value = 46000;
            item.rare = 6;
            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage+= 0.15f;
            player.statManaMax2 += 40;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("IceArmor") && legs.type == mod.ItemType("IceRobe");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Magic hits occasionally grant you the Blizzard's Wrath";
            player.GetModPlayer<MyPlayer>(mod).icySet = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IcyEssence", 16);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}