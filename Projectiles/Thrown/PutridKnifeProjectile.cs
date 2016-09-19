using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class PutridKnifeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Putrid Knife";
            projectile.width = 10;
            projectile.height = 16;

            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;

            projectile.thrown = true;
            projectile.friendly = true;

            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("BlightedFlames"), 60, false);
            }
            MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            mp.PutridHits++;
            if (mp.putridSet && mp.PutridHits >= 4)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("CursedFlame"), projectile.damage, 0f, projectile.owner, 0f, 0f);
                mp.PutridHits = 0;
            }
        }
    }
}
