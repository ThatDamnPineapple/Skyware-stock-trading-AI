using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class LihzahrdMimicSmall : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "LihzahrdMimicSmall";
            npc.displayName = "Lihzahrd Mimic";
            npc.width = 24;
            npc.height = 30;
            npc.damage = 44;
            npc.defense = 18;
            npc.lifeMax = 145;
            npc.soundHit = 4;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = 1f;
            npc.aiStyle = 0;
            aiType = NPCID.BoundGoblin;
            Main.npcFrameCount[npc.type] = 14;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 226) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 1f, 0/25f, 0.2f);
            {
                Player target = Main.player[npc.target];
                int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
                if (distance < 600)
                {
                    npc.ai[0]++;
                    if (npc.ai[0] >= 100)
                    {
                        int type = 258;
                        int p = Terraria.Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, type, (int)((npc.damage * .5)), 0);
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        npc.ai[0] = 0;
                    }
                }
                {

                    npc.spriteDirection = npc.direction;
                }
            }
        }
    }
}
