using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod;

namespace SpiritMod.Projectiles
{

    public class SpiritGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public bool stop = false;
        public float xspeed;
        public float yspeed;
        public bool WitherLeaf = false;
        public bool shotFromStellarCrosbow = false;
        public bool shotFromBloodshot = false;
		public bool shotFromCookieCutter = false;
        public bool shotFromGaruda = false;
        public bool shotFromClatterBow = false;
        public bool shotFromThornBow = false;
        public bool shotFromPalmSword = false;
        public bool shotFromGeodeBow = false;
        public bool shotFromSpazLung = false;
        public bool shotFromCoralBow = false;
        public bool HeroBow1 = false;
        public bool HeroBow2 = false;
        public bool HeroBow3 = false;
        public bool shotFromMarbleBow;
        public override bool PreAI(Projectile projectile)
        {


            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).WitherLeaf == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 3);
                    return true;
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow1 == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.5f;
                    return true;
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow2 == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.5f;
                    return true;
                }
            }
            Player player = Main.player[projectile.owner];
            if (player.GetModPlayer<MyPlayer>(mod).anglure)
            {
                if (projectile.ranged)
                {
                    if (projectile.owner == Main.myPlayer)
                    {
                        projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                        {
                            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 244);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].velocity *= 0f;
                            Main.dust[dust].scale = 1.8f;
                            return true;
                        }
                    }
                }
            }
			
			if (player.GetModPlayer<MyPlayer>(mod).astralSet)
            {
                if (projectile.minion)
                {
                    if (projectile.owner == Main.myPlayer)
                    {
                        if (Main.rand.Next(350) == 1)
						{
							float spread = 10f * 0.0174f;
            double startAngle = Math.Atan2(1, 0) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int i;
            for (i = 0; i < 36; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                int proj1 = Terraria.Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 1.5f), (float)(Math.Cos(offsetAngle) * 1.5f), mod.ProjectileType("AstralFlare"), projectile.damage, 0, projectile.owner);
                int proj2 = Terraria.Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(-Math.Sin(offsetAngle) * 1.5f), (float)(-Math.Cos(offsetAngle) * 1.5f), mod.ProjectileType("AstralFlare"), projectile.damage, 0, projectile.owner);
				
            }
			return true;
						}
                    }
                }
            }
			
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow3 == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldCoin);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.8f;
                    return true;
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromStellarCrosbow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 133);
                return false;
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromBloodshot == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
                return false;
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromGeodeBow == true)
            {

                {
                    projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);
                    int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.2f;
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity *= 0f;
                    Main.dust[dust1].scale = 1.2f;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 1.2f;
                    return false;
                }
            }
			            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromClatterBow == true)
            {
				projectile.magic = false;
				projectile.ranged = true;
			}
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromClatterBow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 147);
                return false;
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromCoralBow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, 172, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, 172, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].scale = 1.2f;
                Main.dust[dust].scale = 1.2f;
                return false;
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromMarbleBow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, DustID.GoldCoin, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, 236, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].scale = .5f;
                Main.dust[dust].scale = 2f;
                return false;
            }
            return base.PreAI(projectile);
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromStellarCrosbow == true)
            {
                target.AddBuff(mod.BuffType("StarFracture"), 300);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromPalmSword == true)
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromPalmSword == true)
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromSpazLung == true)
            {
                target.AddBuff(BuffID.CursedInferno, 120);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).WitherLeaf == true)
            {
                target.AddBuff(mod.BuffType("WitheringLeaf"), 180);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromBloodshot == true)
            {
                target.AddBuff(mod.BuffType("BCorrupt"), 120);
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromClatterBow == true && Main.rand.Next(6) == 0)
            {
                target.AddBuff(mod.BuffType("ClatterPierce"), 120);
            }
            Player player = Main.player[projectile.owner];
            if (player.GetModPlayer<MyPlayer>(mod).anglure)
            {
                if (projectile.ranged)
                {
                    if(Main.rand.Next(8) == 0)
                    {
                        target.AddBuff(mod.BuffType("Marked"), 180);
                    }
                }
            }
			 if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromCookieCutter == true && Main.rand.Next(10) == 0)
            {
                player.AddBuff(mod.BuffType("CrimsonRegen"), 120);
            }
                    if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromThornBow == true && Main.rand.Next(4) == 0)
            {
                int n = Main.rand.Next(5, 6);
                int deviation = Main.rand.Next(0, 300);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 3.5f;
                    perturbedSpeed.Y *= 3.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ThornBowThorn"), projectile.damage / 5 * 3, projectile.knockBack, projectile.owner);
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromGaruda == true && Main.rand.Next(2) == 0)
            {
                int n = Main.rand.Next(1, 2);
                int deviation = Main.rand.Next(0, 300);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 0f;
                    perturbedSpeed.Y *= 7.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 200, 0, 12, mod.ProjectileType("GodHomingProj"), projectile.damage / 2 * 3, projectile.knockBack, projectile.owner);
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromGeodeBow == true)
            {
                if (crit)
                {
                    target.AddBuff(BuffID.CursedInferno, 240, true);
                    target.AddBuff(BuffID.Frostburn, 240, true);
                    target.AddBuff(BuffID.OnFire, 240, true);
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow1 == true)
            {
                {
                    target.AddBuff(BuffID.OnFire, 240, true);

                }
                if (Main.rand.Next(4) == 0)
                {
                    target.AddBuff(BuffID.CursedInferno, 180, true);
                }
                if (Main.rand.Next(8) == 0)
                {
                    target.AddBuff(BuffID.ShadowFlame, 180, true);
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow2 == true)
            {
                {
                    target.AddBuff(BuffID.Frostburn, 120, true);

                }
                if (Main.rand.Next(15) == 0)
                {
                    target.AddBuff(mod.BuffType("DeepFreeze"), 180, true);
                }
            }
            if (projectile.GetGlobalProjectile<SpiritGlobalProjectile>(mod).HeroBow3 == true)
            {
                if (Main.rand.Next(100) == 2)
                {
                    target.AddBuff(mod.BuffType("Death"), 240, true);
                }
            }
        }
    }
}
