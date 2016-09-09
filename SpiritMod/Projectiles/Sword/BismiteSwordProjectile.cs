using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Sword
{

    public class BismiteSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            
            projectile.name = "BismiteSwordProjectile";  
            projectile.width = 20;       
            projectile.height = 26;  
            projectile.friendly = true;      
            projectile.melee = true;          
            projectile.tileCollide = true;   
            projectile.penetrate = 1;      
            projectile.timeLeft = 500;      
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

        }
        public override void AI()
        {
            projectile.rotation += 0.1f;

        }
    }
}