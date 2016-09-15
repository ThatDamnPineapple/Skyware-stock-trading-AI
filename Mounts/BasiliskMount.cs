using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Mounts
{
	class BasiliskMount : ModMountData
	{
		private const float damage = 45f;
		private const float knockback = 8f;

		public override void SetDefaults()
		{
			mountData.spawnDust = DustID.Stone;
			mountData.buff = mod.BuffType("RidingBasilisk");
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 1.5f; //0.2
			mountData.runSpeed = 4f; //4
			mountData.dashSpeed = 10f; //12
			mountData.acceleration = 0.2f; //0.3
			mountData.jumpHeight = 12; //10
			mountData.jumpSpeed = 6.01f; //8.01
			mountData.blockExtraJumps = false;
			mountData.fatigueMax = 0;
			mountData.bodyFrame = 3;
			mountData.heightBoost = 16;
			mountData.xOffset = 10;
			mountData.yOffset = 13;
			mountData.playerHeadOffset = 16;
			mountData.totalFrames = 8;
			int[] offsets = new int[mountData.totalFrames];
			for (int i = 0; i < offsets.Length; i++)
			{
				offsets[i] = 15;
			}
			offsets[0] -= 1;
			offsets[1] += 1;
			offsets[3] += 1;
			offsets[4] -= 1;
			offsets[6] += 1;
			mountData.playerYOffsets = offsets;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 6;
			mountData.runningFrameDelay = 22;
			mountData.runningFrameStart = 2;
			mountData.dashingFrameCount = 6;
			mountData.dashingFrameDelay = 40;
			mountData.dashingFrameStart = 2;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 12;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 1;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = false;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode != 2)
			{
				mountData.textureWidth = mountData.backTexture.Width + 20;
				mountData.textureHeight = mountData.backTexture.Height;
			}
		}

		public override void UpdateEffects(Player player)
		{
			if (Math.Abs(player.velocity.X) > player.mount.DashSpeed - player.mount.RunSpeed / 2f)
			{
				player.noKnockback = true;

				Rectangle rect = player.getRect();
				//Tweak hitbox to be the Basilisks head
				rect.Width = 2;
				rect.Height = 2;
				if (player.direction == 1)
				{
					rect.Offset(player.width - 1, 0);
				}
				rect.Offset(0, player.height - 19);
				rect.Inflate(28, 16);

				for (int n = 0; n < Main.maxNPCs; n++)
				{
					NPC npc = Main.npc[n];
					if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.immune[player.whoAmI] == 0)
					{
						Rectangle rect2 = npc.getRect();
						if (rect.Intersects(rect2) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
						{
							float damage = BasiliskMount.damage * player.minionDamage;
							float knockback = BasiliskMount.knockback * player.minionKB;
							int direction = player.direction;
							if (player.velocity.X < 0f)
							{
								direction = -1;
							}
							if (player.velocity.X > 0f)
							{
								direction = 1;
							}
							if (player.whoAmI == Main.myPlayer)
							{
								player.ApplyDamageToNPC(npc, (int)damage, knockback, direction, false);
							}
							npc.immune[player.whoAmI] = 30;
							player.immune = true;
							player.immuneTime = 6;
							return;
						}
					}
				}
			}
		}
	}
}
