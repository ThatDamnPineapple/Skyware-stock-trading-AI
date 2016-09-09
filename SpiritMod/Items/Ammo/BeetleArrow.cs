using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class BeetleArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Beetle Arrow";
			item.shootSpeed = 2.5f;
			item.shoot = mod.ProjectileType("BeetleArrow");
			item.damage = 16;
			item.width = 10;
			item.height = 28;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 2f;
			item.value = 450;
			item.ranged = true;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe rcp = new ModRecipe(mod);
			rcp.AddIngredient(ItemID.BeetleHusk, 2);
			rcp.AddTile(TileID.MythrilAnvil);
			rcp.SetResult(this, 111);
			rcp.AddRecipe();
		}
	}
}
