using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class SilkRobe : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Silk Robe";
            item.width = 32;
            item.height = 30;
            AddTooltip("Increases max number of minions by 1");
            item.value = 12000;
            item.rare = 2;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 14);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Silk, 14);
            recipe2.AddIngredient(ItemID.PlatinumBar, 2);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}