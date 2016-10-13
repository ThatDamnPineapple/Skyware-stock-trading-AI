using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class Starfall : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Starfall";
			item.damage = 38;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Shoots a starry bolt.";
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StarfallProjectile");
			item.shootSpeed = 14f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			player.channel = true;
			Vector2 mouse = new Vector2(Main.mouseX,Main.mouseY) + Main.screenPosition;
            for (int i = 0; i < 5; ++i)
            {
				  float Xdis = ((mouse.X - 50) + Main.rand.Next(100)) - position.X;  // change myplayer to nearest player in full version
			float Ydis = (mouse.Y - 600) - position.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrijectoryX = (float)(Math.Sin(Angle));
			float TrijectoryY = (float)(Math.Cos(Angle));
				Terraria.Projectile.NewProjectile((position.X - 50) + Main.rand.Next(100), position.Y - 600, 0 - (TrijectoryX * Main.rand.Next(13,15)), (TrijectoryY * Main.rand.Next(13,15)), type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
	}
}