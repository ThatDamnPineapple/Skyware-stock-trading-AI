using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class MartianArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Electrified Arrow";
			item.shootSpeed = 1f;
			item.shoot = mod.ProjectileType("ElectricArrow");
			item.damage = 16;
			item.width = 14;
			item.height = 30;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 2f;
			item.value = 12000;
			item.ranged = true;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe rcp = new ModRecipe(mod);
            rcp.AddIngredient(null, "MartianCore", 1);
            rcp.AddTile(TileID.MythrilAnvil);
			rcp.SetResult(this, 50);
			rcp.AddRecipe();
		}
	}
}
