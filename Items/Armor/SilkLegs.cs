using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class SilkLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Silken Leggings";
            item.width = 26;
            item.height = 18;
            AddTooltip("Increases Minion Damage by 4%");
            item.value = 1000;
            item.rare = 2;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            item.toolTip = "Increases Minion Damage by 4%";
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 12);
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Silk, 12);
            recipe2.AddIngredient(ItemID.PlatinumBar, 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}