using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Projectiles.Arrow
{
	class TikiArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.name = "Tiki Arrow";
			projectile.extraUpdates = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			NInfo modNPC = target.GetModInfo<NInfo>(mod);
			if (target.life <= 0)
			{
				//Workaround: OnHitNPC gets called after NPCLoot for some reason.
				Vector2 pos = target.Center;
				Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, TikiBiter._ref.projectile.type, (int)(projectile.damage * 0.75f), 0f, projectile.owner, -1f);
			}
            else
			{
				target.AddBuff(Buffs.TikiInfestation._ref.Type, Buffs.TikiInfestation.duration);
				modNPC.AddTikiSource(projectile);
			}
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 2);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}
