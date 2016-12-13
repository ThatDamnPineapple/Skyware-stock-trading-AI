using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Worker : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Worker";
            npc.displayName = "Worker";
            npc.width = 50;
            npc.height = 30;
            npc.damage = 80;
            npc.defense = 28;
            npc.lifeMax = 600;
            npc.soundHit = 2;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 3;
            aiType = NPCID.DesertBeast;
            Main.npcFrameCount[npc.type] = 6;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 2) && NPC.downedMoonlord && spawnInfo.spawnTileY < Main.rockLayer ? 0.1f : 0f;
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
            npc.spriteDirection = npc.direction;

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Toxify"), 680);
        }
    }
}
