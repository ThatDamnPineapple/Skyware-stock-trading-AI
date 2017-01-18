using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class FPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Floran Plate";
            item.width = 34;
            item.height = 18;
            AddTooltip("+2% Magic Damage and +20 max mana");
            item.value = 11000;
            item.rare = 2;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.magicDamage *= 1.02f; //20 max mana
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 14);   //you need 10 Wood
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}