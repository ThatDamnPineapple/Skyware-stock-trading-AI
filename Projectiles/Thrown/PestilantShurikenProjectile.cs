using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Thrown {
public class PestilantShurikenProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.name = "Pestilent Shuriken";
		projectile.width = 22;
		projectile.height = 22;
		projectile.aiStyle = 2;
		projectile.penetrate = 4;
		projectile.thrown = true;
		projectile.friendly = true;
		projectile.alpha = 0;
		
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		projectile.penetrate--;
		if (projectile.penetrate <= 0)
		{
			projectile.Kill();
		}
       
		if (projectile.velocity.X != oldVelocity.X)
		{
			projectile.velocity.X = -oldVelocity.X;
		}
		if (projectile.velocity.Y != oldVelocity.Y)
		{
			projectile.velocity.Y = -oldVelocity.Y * 1.3f;
		}
		Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		return false;
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
}}
