using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class CaptainsRegards : ModItem
    {private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Captain's Regards";  
            item.damage = 35;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 8;
			 item.toolTip = "'Pirate diplomacy at its finest'";
            item.useAnimation = 8;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 36;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 7f;
            item.useAmmo = ProjectileID.Bullet;
        }
		
		            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(8) == 1)
			{
				int proj = Projectile.NewProjectile(position.X, position.Y, 2 * speedX, 2 * speedY, 162, damage, knockBack, player.whoAmI);
				Projectile newProj = Main.projectile[proj];
				newProj.friendly = true;
					newProj.hostile = false;
			}
			Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X <= 7; X++)
			{
				if (Main.rand.Next(2) == 1)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(92, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(92, 1800) / 10));
				}
			int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
			Projectile newProj2 = Main.projectile[proj2];
					newProj2.timeLeft = Main.rand.Next(30);
			}
			return false;
        }
		
    }
}