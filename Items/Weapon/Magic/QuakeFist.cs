using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class QuakeFist : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Quake Fist";
			item.damage = 19;
			item.magic = true;
			item.mana = 13;
			item.width = 28;
			item.height = 30;
			item.toolTip = "Launches Prismatic fire";
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;//this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PrismaticBolt");
			item.shootSpeed = 16f;
		}
	}
}