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
            npc.damage = 16;
            npc.defense = 8;
            npc.lifeMax = 59;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 3290f;
            npc.knockBackResist = .65f;
            npc.aiStyle = 3;
            aiType = NPCID.AngryBones;
            Main.npcFrameCount[npc.type] = 15;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDesert ? 0.08f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 825);
                Gore.NewGore(npc.position, npc.velocity, 826);
                Gore.NewGore(npc.position, npc.velocity, 827);
            }
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
