using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow.Artifact
{
    public class StarPin1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Pin");

        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.penetrate = 4;
            projectile.timeLeft = 240;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            projectile.CloneDefaults(ProjectileID.Bullet);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 244);
            }

            if (Main.rand.Next(2) == 1)
            {
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 6, -2, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -6, -2, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3, 5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3, 5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
            }
        }
        public override void AI()
        {
			MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            if (mp.MoonSongBlossom)
			{
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust2].velocity *= 0f;
            Main.dust[dust2].scale = 0.6f;
            Main.dust[dust].scale = 0.6f;
            Lighting.AddLight(projectile.position, 0.224f, 0.139f, 0.29f);
			}
			{
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 244, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 244, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust2].velocity *= 0f;
            Main.dust[dust2].scale = 0.6f;
            Main.dust[dust].scale = 0.6f;
            Lighting.AddLight(projectile.position, 0.224f, 0.139f, 0.29f);
			}
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180);
            }
            if (crit)
            {
                Player player = Main.player[projectile.owner];
                for (int i = 0; i < 3; ++i)
                {

                    if (Main.myPlayer == player.whoAmI)
                    {
                        Vector2 mouse = Main.MouseWorld;
                        Projectile.NewProjectile(mouse.X + Main.rand.Next(-80, 80), projectile.position.Y - 1000 + Main.rand.Next(-50, 50), 0, Main.rand.Next(10, 20), mod.ProjectileType("AstralArrow"), projectile.damage / 5 * 4, projectile.knockBack, Main.myPlayer);
                    }
                }
            }
            if (Main.rand.Next(4) == 1)
            {
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 6, -2, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -6, -2, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3, 5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3, 5, mod.ProjectileType("StarEnergyBolt"), projectile.damage, 0.4f, Main.myPlayer);
            }
        }
    }
}
