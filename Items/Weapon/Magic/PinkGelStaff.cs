using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class PinkGelStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Roseslime Staff";
			item.damage = 13;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 36;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 20000;
			item.rare = 3;
			item.useSound = 20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("PinkGelProj");
			item.shootSpeed = 10f;
            item.toolTip = "Shoots Bouncy Blobs of Slime at foes!";
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkGel, 10);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
