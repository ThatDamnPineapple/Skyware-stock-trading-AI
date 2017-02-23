using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class Mako : ModItem

    {private Vector2 newVect;

        public override void SetDefaults()
        {
            item.name = "The Mako";  
            item.damage = 36;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 18;
			 item.toolTip = "'Turns bullets into Crystal rounds'";
            item.useAnimation = 24;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 7;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.crit = 10;
			item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 89; 
            item.shootSpeed = 25f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        { 
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 89, damage, knockBack, player.whoAmI);
        }
			return false;
        }
		
    }
}
