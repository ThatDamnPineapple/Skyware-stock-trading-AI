using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RoguePants : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Rogue Greaves";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases throwing velocity by 5%");
            item.value = 500;
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.05f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OldLeather", 4);
            recipe.AddIngredient(ItemID.CopperBar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OldLeather", 4);
            recipe.AddIngredient(ItemID.TinBar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}