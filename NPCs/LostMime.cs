using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class LostMime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Lost Mime";
            npc.displayName = "Lost Mime";
            npc.width = 24;
            npc.height = 42;
            npc.damage = 20;
            npc.defense = 8;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit48;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 2060f;
            npc.knockBackResist = .65f;
            npc.aiStyle = 3;
            aiType = NPCID.AngryBones;
            Main.npcFrameCount[npc.type] = 17;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
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
            npc.spriteDirection = npc.direction;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Confused, 60);
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
    }
}
