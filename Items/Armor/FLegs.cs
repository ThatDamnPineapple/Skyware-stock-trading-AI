using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FLegs : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floran Leggings");
            Tooltip.SetDefault("4% increased movement speed and 3% increased magic damage");

        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = 2;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed += 0.04f;
            player.magicDamage += 0.03f; //player movement speed incresed 0.05f = 5%
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 14);   //you need 10 Wood
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}