using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class TikiArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Tiki Arrow";
			item.shootSpeed = 2f;
			item.shoot = mod.ProjectileType("TikiArrow");
			item.damage = 12;
			item.width = 10;
			item.height = 28;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = 1;
			item.knockBack = 2f;
			item.value = 100;
			item.ranged = true;
			item.rare = 8;
		}
	}
}
