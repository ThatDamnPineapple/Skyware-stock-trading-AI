using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class TalonGarb : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Talon Garb");
            Tooltip.SetDefault("Increases ranged and magic critical strike chance by 4%\n4% increased movement speed");

        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 22;
            item.value = 10000;
            item.rare = 3;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.rangedCrit += 4;
            player.moveSpeed += 0.04f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Talon", 16);
            recipe.AddIngredient(null, "FossilFeather", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
