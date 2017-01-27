using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class TitaniumStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Titanium Staff";
			item.damage = 50;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 37;
			item.useAnimation = 37;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 2000;
			item.rare = 6;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TitaniumStaffProj");
			item.shootSpeed = 30f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
