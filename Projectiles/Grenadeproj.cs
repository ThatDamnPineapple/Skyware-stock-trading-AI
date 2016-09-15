using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class Grenadeproj : ModProjectile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "SpiritMod/Items/Weapon/Thrown/MartianGrenade";
            return true;
        }

        public override void SetDefaults()
        {
            ///for reasons, I have to put a comment here.
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.name = "Electrosphere Grenade";
            projectile.timeLeft = 180;
            projectile.width = 20;
            projectile.height = 20;
        }

        public override void Kill(int timeLeft)
        {
            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileID.Electrosphere, (int)(projectile.damage), 0, Main.myPlayer);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
    }
}