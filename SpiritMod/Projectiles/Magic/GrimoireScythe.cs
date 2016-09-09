using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class GrimoireScythe : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "Grimoire Scythe";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 5;

        }
		
				public override bool PreAI()
		{
			projectile.rotation += 0.1f;
			timer++;
			if (timer >= 60)
			{
				projectile.velocity *= 1.2f;
			}
			            if (Main.rand.Next(5) == 0)
            		{
                		int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust].scale = 3f;
				Main.dust[dust].noGravity = true;		
            		}
	
			return true;
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
