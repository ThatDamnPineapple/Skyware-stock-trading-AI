using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class GoreStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gore Staff";
			item.damage = 42;
			item.magic = true;
			item.mana = 16;
			item.width = 40;
			item.height = 40;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 6;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("IchorBomb");
			item.shootSpeed = 6f;
		}
		
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
