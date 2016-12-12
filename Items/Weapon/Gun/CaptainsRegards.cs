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
            item.damage = 25;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 14;
			 item.toolTip = "'Pirate diplomacy at its finest'";
            item.useAnimation = 14;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 6;
			item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Bullet;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 162, damage, knockBack, player.whoAmI);
				Projectile newProj = Main.projectile[proj];
				newProj.friendly = true;
					newProj.hostile = false;
			Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X <= 3; X++)
			{
				if (Main.rand.Next(2) == 1)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
				}
			int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
			Projectile newProj2 = Main.projectile[proj2];
					newProj2.timeLeft = Main.rand.Next(13, 30);
			}
			return false;
        }
		
    }
}
