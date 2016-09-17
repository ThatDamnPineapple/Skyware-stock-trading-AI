using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class AntlionAssassin : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Antlion Assassin";
            npc.displayName = "Antlion Assassin";
            npc.width = 24;
            npc.height = 44;
            npc.damage = 19;
            npc.defense = 8;
            npc.lifeMax = 65;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .65f;
            npc.aiStyle = 3;
            aiType = NPCID.AngryBones;
            Main.npcFrameCount[npc.type] = 15;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDesert ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
    }
}
