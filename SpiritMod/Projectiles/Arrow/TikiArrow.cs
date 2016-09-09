using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			NPCs.NPCData modNPC = target.GetModInfo<NPCs.NPCData>(mod);
			if (target.life <= 0)
			{
				//Workaround: OnHitNPC gets called after NPCLoot for some reason.
				Vector2 pos = target.Center;
				Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, TikiBiter._ref.projectile.type, (int)(projectile.damage * 0.75f), 0f, projectile.owner, -1f);
			} else
			{
				target.AddBuff(Buffs.TikiInfestation._ref.Type, Buffs.TikiInfestation.duration);
				modNPC.AddTikiSource(projectile);
			}
		}

	}
}
