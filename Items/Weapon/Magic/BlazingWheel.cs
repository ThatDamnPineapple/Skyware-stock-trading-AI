using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class BlazingWheel : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blazing Wheel";
			item.damage = 22;
			item.magic = true;
			item.mana = 14;
			item.width = 28;
			item.height = 30;
			item.toolTip = "Shoots a Wheel of Fire.";
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 54000;
			item.rare = 3;
			item.useSound = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlazingWheelProj");
			item.shootSpeed = 16f;
		}
	}
}