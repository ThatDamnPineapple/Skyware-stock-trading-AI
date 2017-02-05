using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class NecropolisStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Necropolis Staff";
			item.damage = 42;
            item.toolTip = "Shoots a slow moving trident";
			item.magic = true;
			item.mana = 13;
			item.width = 40;
			item.height = 40;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 6;
			item.value = 2500;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecropolisTrident");
			item.shootSpeed = 4f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
