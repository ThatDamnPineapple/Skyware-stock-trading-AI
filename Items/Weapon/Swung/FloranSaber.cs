using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
	public class FloranSaber : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Floran Saber";
            item.damage = 20;            
            item.melee = true;
            item.width = 40;
            item.height = 40;
			item.toolTip = "Sharp as a Razorleaf.";
			item.useTime = 30;
			item.useAnimation = 25;
            item.useStyle = 1;
			item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "FloranBar", 10);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
		}
    }
}