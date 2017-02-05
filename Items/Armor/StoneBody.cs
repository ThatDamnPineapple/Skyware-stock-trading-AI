using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class StoneBody : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Stone Plate";
            item.width = 30;
            item.height = 20;
            AddTooltip("Decreases movement speed by 5%");
            item.value = 600;
            item.rare = 1;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.05f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}