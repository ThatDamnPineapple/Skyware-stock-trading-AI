using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class ShroomiteArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shroomite Arrow";
			item.shootSpeed = 4f;
			item.shoot = mod.ProjectileType("ShroomiteArrow");
			item.damage = 16;
			item.width = 10;
			item.height = 28;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 0f;
			item.value = 1000;
			item.ranged = true;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe rcp = new ModRecipe(mod);
			rcp.AddIngredient(ItemID.ShroomiteBar);
			rcp.AddTile(TileID.MythrilAnvil);
			rcp.SetResult(this, 50);
			rcp.AddRecipe();
		}
	}
}
