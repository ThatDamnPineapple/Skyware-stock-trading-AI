using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Spirit
{
	public class Hedron : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Hedron";
			npc.width = 32;
			npc.height = 32;
			npc.lifeMax = 350;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.friendly = false;
			Main.npcFrameCount[npc.type] = 8;
		}

		public override bool PreAI()
		{
			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = npc.Center.Y;
			}
			if (npc.Center.Y >= npc.localAI[0])
			{
				npc.localAI[1] = -1f;
			}
			if (npc.Center.Y <= npc.localAI[0] - 40f)
			{
				npc.localAI[1] = 1f;
			}
			npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y + 0.05f * npc.localAI[1], -2f, 2f);
			npc.ai[0] += 1f;
			if (npc.ai[0] >= 90f)
			{
				bool hasTarget = false;
				Vector2 target = Vector2.Zero;
				float targetRange = 640f;//1600 was too much
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						float playerX = Main.player[i].position.X + (float)(Main.player[i].width / 2);
						float playerY = Main.player[i].position.Y + (float)(Main.player[i].height / 2);
						float distOrth = Math.Abs(npc.position.X + (float)(npc.width / 2) - playerX) + Math.Abs(npc.position.Y + (float)(npc.height / 2) - playerY);
						if (distOrth < targetRange)
						{
							targetRange = distOrth;
							target = Main.player[i].Center;
							hasTarget = true;
						}
					}
				}
				if (hasTarget)
				{
					Vector2 delta = target - npc.Center;
					delta.Normalize();
					delta *= 6f;
					int slot = Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, 84, 10, 1f, Main.myPlayer, 0f, 0f);
					Main.projectile[slot].tileCollide = false;
					Main.projectile[slot].netUpdate = true;
				}
				npc.ai[0] = 0f;
			}
			return false;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneSpirit ? 1f : 0f;
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 13);
                Gore.NewGore(npc.position, npc.velocity, 12);
                Gore.NewGore(npc.position, npc.velocity, 11);
            }
        }
        public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.10000000149011612;
			npc.frameCounter %= (double)Main.npcFrameCount[npc.type];
			int num = (int)npc.frameCounter;
			npc.frame.Y = num * frameHeight;
			npc.spriteDirection = npc.direction;
		}
	}
}
