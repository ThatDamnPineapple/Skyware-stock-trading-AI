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
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
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
