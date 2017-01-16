using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class SpiritRune : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Rune";
			item.damage = 34;
			item.magic = true;
			item.mana = 20;
			item.width = 28;
			item.height = 32;
			item.toolTip = "'Contains ancient energy'";
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 2800;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("RuneBook");
			item.shootSpeed = 2f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 10);
            recipe.AddIngredient(531, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
