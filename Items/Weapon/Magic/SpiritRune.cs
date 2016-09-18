using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class SpiritRune : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Rune";
			item.damage = 29;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.toolTip = "'Contains ancient energy'";
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("RuneBook");
			item.shootSpeed = 2f;
		}
	}
}