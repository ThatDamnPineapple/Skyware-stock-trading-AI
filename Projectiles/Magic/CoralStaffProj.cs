using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class CoralStaffProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Whirlpool";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 27;
            projectile.width = 50;
            projectile.height = 50;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 180;
        }

        public override bool PreAI()
        {
            projectile.tileCollide = false;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f);
            int dust3 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f);
            Main.dust[dust].scale = 1.5f;
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].scale = 1.5f;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust3].scale = 1.5f;
            Main.dust[dust3].noGravity = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, 0f, 0f); //to make some with gravity to fly all over the place :P
            return false;
        }
    }
}