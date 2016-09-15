using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class DuskBall : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Dusk Sphere";
            npc.width = 16;
            npc.height = 16;
            npc.alpha = 255;

            npc.damage = 70;
            npc.defense = 0;
            npc.lifeMax = 1;
            npc.knockBackResist = 0;

            npc.friendly = false;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.soundHit = 3;
            npc.soundKilled = 3;

            Main.npcFrameCount[npc.type] = 4;
        }

        public override bool PreAI()
        {
            if (npc.target == 255)
            {
                npc.TargetClosest(true);
                float num1 = 6f;
                Vector2 vector2 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                float num2 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector2.X;
                float num3 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector2.Y;
                float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                float num5 = num1 / num4;
                npc.velocity.X = num2 * num5;
                npc.velocity.Y = num3 * num5;
            }

            if (npc.timeLeft > 100)
                npc.timeLeft = 100;

            if (npc.alpha > 0)
                npc.alpha -= 41;
            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.frameCounter++ >= 10)
            {
                npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
                npc.frameCounter = 0;
            }            
        }
    }
}
