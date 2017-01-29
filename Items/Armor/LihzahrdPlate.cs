using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class LihzahrdPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Lihzahrd Plate";
            item.width = 30;
            item.height = 20;
            AddTooltip("Increased thrown velocity by 20% and movement speed by 20%");
            item.value = 80000;
            item.rare = 7;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.2f;
			player.thrownVelocity += 0.2f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2766, 18);
            recipe.AddTile(TileID.MythrilAnvil);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}