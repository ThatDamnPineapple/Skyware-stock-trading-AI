using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class InfernalGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Infernal Greaves";
            item.width = 28;
            item.height = 20;
            item.toolTip = "Increases magic critical chance by 7% and reduces mana consumption by 10%";
            item.rare = 6;
            item.value = 42000;

            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 7;
            player.manaCost -= 0.10f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "InfernalAppendage", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

    }
}
