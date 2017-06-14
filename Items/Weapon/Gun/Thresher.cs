using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class Thresher : ModItem
    {
        private Vector2 newVect;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Thresher");
			Tooltip.SetDefault("'Fires a blast of bullets and mutilated material'");
		}


        public override void SetDefaults()
        {
            item.damage = 28;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 7;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = 10; 
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 307, damage, knockBack, player.whoAmI);
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
			}
			return false;
        }
		
    }
}
