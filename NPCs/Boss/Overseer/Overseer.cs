using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Overseer
{
    public class Overseer : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Overseer";
            npc.width = 148;
            npc.height = 172;

            npc.damage = 30;
            npc.defense = 55;
            npc.lifeMax = 65000;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = false;

            npc.npcSlots = 10;

            //npc.soundHit = 7;
            //npc.soundKilled = 5;

            Main.npcFrameCount[npc.type] = 6;
        }

        public override bool PreAI()
        {
            if (npc.ai[0] == 0)
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 180)
                {
                    npc.TargetClosest(true);

                    Vector2 dir = Main.player[npc.target].Center - npc.Center;
                    dir.Normalize();
                    dir *= 8;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, dir.X, dir.Y, mod.ProjectileType("HauntedWisp"), 10, 0, Main.myPlayer);

                    npc.ai[1] = 0;
                }
            }
            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 5)
            {
                npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
                npc.frameCounter = 0;
            }
        }
    }
}
