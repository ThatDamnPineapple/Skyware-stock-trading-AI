using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PestilentLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Pestilent Leggings";
            item.width = 34;
            item.height = 30;
            AddTooltip("15% increased movement speed");
            item.value = 10;
            item.rare = 8;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
        } 
        
        		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
