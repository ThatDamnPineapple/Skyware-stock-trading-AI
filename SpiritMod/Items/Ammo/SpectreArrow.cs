using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class SpectreArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ghast Arrow";
			item.shootSpeed = 1f;
			item.shoot = mod.ProjectileType("SpectreArrow");
			item.damage = 14;
			item.width = 10;
			item.height = 28;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 2f;
			item.value = 1000;
			item.ranged = true;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe rcp = new ModRecipe(mod);
			rcp.AddIngredient(ItemID.SpectreBar);
			rcp.AddTile(TileID.MythrilAnvil);
			rcp.SetResult(this, 50);
			rcp.AddRecipe();
		}
	}
}
