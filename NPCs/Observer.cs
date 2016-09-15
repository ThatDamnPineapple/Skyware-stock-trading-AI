using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
namespace SpiritMod.NPCs
{
    public class Observer : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Observer";
            npc.displayName = "Observer";
            npc.width = 36;
            npc.height = 44;
            npc.damage = 44;
            npc.defense = 20;
            npc.lifeMax = 160;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .10f;
            npc.aiStyle = 22;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryNimbus];
            aiType = NPCID.Wraith;
            animationType = NPCID.AngryNimbus;
        }
        public override void AI()
        {
            Player target = Main.player[npc.target];
            int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
            if (distance < 320)
            {
                npc.ai[3]++;
                if (npc.ai[3] >= 200)
                {
                    int type = mod.ProjectileType("Eyebeam"); 
                    int p = Terraria.Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, type, (int)((npc.damage * .5)), 0);
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                    npc.ai[3] = 0;
                }
            }
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }


        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
