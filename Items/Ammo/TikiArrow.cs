using System;

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
            item.toolTip = "Enemies hit by Tiki Arrows are filled with Tiki Spirits, killing them releases the angry spirits to fight for you!";
			item.width = 10;
			item.height = 28;
            item.rare = 8;
            item.value = 100;

            item.maxStack = 999;

            item.damage = 12;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("TikiArrow");
            item.shootSpeed = 2f;
        }
	}
}
