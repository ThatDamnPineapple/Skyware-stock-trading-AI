using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class CobaltStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cobalt Staff";
			item.damage = 39;
			item.magic = true;
			item.mana = 6;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 1;
			item.value = 0200;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CobaltStaffProj");
			item.shootSpeed = 20f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
