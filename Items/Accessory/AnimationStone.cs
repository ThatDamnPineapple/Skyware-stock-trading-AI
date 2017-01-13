using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class AnimationStone : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Animation Stone";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "Increases life regen and invincibility time slightly";
			item.toolTip2 = "'The night is dark and full of terrors'";
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = 2;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.1f;   
			player.jumpSpeedBoost -= 1f;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock,50);
			recipe.AddIngredient(ItemID.DemoniteBar,50);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock,50);
			recipe.AddIngredient(ItemID.CrimtaneBar,50);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
