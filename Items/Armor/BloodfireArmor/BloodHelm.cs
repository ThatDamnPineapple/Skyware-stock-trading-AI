using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.BloodfireArmor
{
    public class BloodHelm : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bloodfire Mask";
            item.width = 20;
            item.height = 18;
            AddTooltip("Increases magic damage and critical strike chance by 5%");
            AddTooltip("Increases maximum mana by 30");
            item.value = 11000;
            item.rare = 2;
            item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 30;
            player.magicDamage += .05f;
            player.magicCrit += 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BloodPlate") && legs.type == mod.ItemType("BloodGreaves");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Magic attacks may inflict 'Blood Corruption' \n Magic attacks may rarely steal life";
            player.GetModPlayer<MyPlayer>(mod).bloodfireSet = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodFire", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}