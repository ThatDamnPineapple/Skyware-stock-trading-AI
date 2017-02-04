using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RunicGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Runic Greaves";
            item.width = 34;
            item.height = 30;
            AddTooltip("Reduces mana cost by 15% and Increases immmunity frames.");
            item.value = 60000;
            item.rare = 5;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.15f;
            player.immuneTime *= 2;


        }    
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}