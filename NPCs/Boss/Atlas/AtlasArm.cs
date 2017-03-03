using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Atlas
{
    public class AtlasArm : ModNPC
    {
        // npc.ai[0] = state manager.

        Vector2 leftArmRoot = new Vector2(-40, 10);
        Vector2 rightArmRoot = new Vector2(40, 10);
		int collideTimer = 0;

        public override void SetDefaults()
        {
            npc.name = "Atlas Arm";
            npc.width = 120;
            npc.height = 260;

            npc.damage = 35;
            npc.lifeMax = 10;

            npc.boss = true;
            npc.noGravity = true;
            npc.dontTakeDamage = true;

            npc.alpha = 255;
        }

        public override bool PreAI()
        {
            for (int index = 3; index > 0; --index)
            {
                npc.oldPos[index] = npc.oldPos[index - 1];
                npc.oldRot[index] = npc.oldRot[index - 1];
            }
            npc.oldPos[0] = npc.position;
            npc.oldRot[0] = npc.rotation;

            if (npc.ai[0] == 0) // Spawn sequence (appearing).
            {
                npc.ai[1]++;
                if(npc.ai[1] >= (160 + 30 * npc.ai[3]))
                {
                    npc.alpha -= 4;
                    if (npc.alpha <= 0)
                    {
                        npc.ai[0] = 1;
                        npc.ai[1] = 0;

                        npc.alpha = 0;
                    }
                }
            }
            else if(npc.ai[0] == 1) // Move down untill collision occurs. Then shitty mod and stop movement.
            {
                if (npc.ai[1] == 0)
                {
                    npc.velocity.Y = 16;
                    if (npc.collideY)
                    {
                        SpiritMod.shittyModTime = 60;
                        npc.ai[1] = 1;
                    }
                }
                else if(npc.ai[1] == 1)
                {
                    npc.velocity *= 0;
                }
            }
            else if(npc.ai[0] == 2) // Move to root point on Atlas boss.
            {
                NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("Atlas"))];

                Vector2 moveDir = (parent.position + (npc.ai[3] == -1 ? leftArmRoot : rightArmRoot)) - npc.position;
                moveDir.Normalize();
                npc.velocity += moveDir / 5;
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -10, 10);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -10, 10);

                npc.rotation = npc.velocity.X / 20;
            }
			
			collideTimer++;
			if (collideTimer == 400)
			{
			npc.noTileCollide = true;
			}

            npc.direction = npc.spriteDirection = -(int)npc.ai[3];

            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (npc.velocity != Vector2.Zero)
            {
                Texture2D texture = Main.npcTexture[npc.type];
                Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

                for (int i = 1; i < npc.oldPos.Length; ++i)
                {
                    Vector2 vector2_2 = npc.oldPos[i];
                    Microsoft.Xna.Framework.Color color2 = Color.White * npc.Opacity;
                    color2.R = (byte)(0.5 * (double)color2.R * (double)(10 - i) / 20.0);
                    color2.G = (byte)(0.5 * (double)color2.G * (double)(10 - i) / 20.0);
                    color2.B = (byte)(0.5 * (double)color2.B * (double)(10 - i) / 20.0);
                    color2.A = (byte)(0.5 * (double)color2.A * (double)(10 - i) / 20.0);
                    Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.oldPos[i].X - Main.screenPosition.X + (npc.width / 2),
                        npc.oldPos[i].Y - Main.screenPosition.Y + npc.height / 2), new Rectangle?(npc.frame), color2, npc.oldRot[i], origin, npc.scale, SpriteEffects.None, 0.0f);
                }
            }
            return true;
        }
    }
}
