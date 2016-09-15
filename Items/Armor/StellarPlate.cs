using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class StellarPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Stellar Plate";
            item.width = 34;
            item.height = 30;
            AddTooltip("10% increased ranged damage and critical strike chace");
            item.value = 10;
            item.rare = 8;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.10f;
            player.rangedCrit += 10;
        }
        
        		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
