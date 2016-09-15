using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
	public class BlightedBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Blighted Bullet";
            projectile.width = 2;
            projectile.height = 2;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("BlightedFlames"), 60, false);
            }
            			Player player = Main.player[projectile.owner];
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).PutridHits++;
			if (((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).PutridHits >= 4 && ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).PutridSetbonus == true)
			{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("CursedFlame"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).PutridHits = 0;
			}
        }
    }
}
