using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class MartianScout : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Martian Scout";
            npc.displayName = "Martian Scout";
            npc.width = 40;
            npc.height = 40;
            npc.damage = 42;
            npc.defense = 28;
            npc.lifeMax = 120;
            npc.soundHit = 43;
            npc.soundKilled = 45;
            npc.value = 60f;
            npc.knockBackResist = .8f;
            npc.aiStyle = 3;
            aiType = NPCID.GrayGrunt;
            Main.npcFrameCount[npc.type] = 9;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky && Main.hardMode ? 0.1f : 0f;
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
