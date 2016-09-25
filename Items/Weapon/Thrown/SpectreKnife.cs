using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class SpectreKnife : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spectre Knife";
			item.width = 16;
			item.height = 24;
			item.toolTip = "";
			item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
			item.rare = 9;
			item.maxStack = 999;
			item.crit = 6;
			item.damage = 65;
			item.knockBack = 3.5f;
			item.useStyle = 1;
			item.useTime = 15;
			item.useAnimation = 15;
			item.thrown = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("SpectreKnifeProj");
			item.shootSpeed = 11f;
		}
	}
}