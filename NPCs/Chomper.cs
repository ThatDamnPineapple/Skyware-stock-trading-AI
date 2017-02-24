using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Chomper : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Chomper";
            npc.displayName = "Chomper";
            npc.width = 34;
            npc.height = 32;
            npc.damage = 25;
            npc.defense = 12;
            npc.lifeMax = 90;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 960f;
            npc.knockBackResist = .8f;
            npc.aiStyle = 25;
            aiType = NPCID.Mimic;
            Main.npcFrameCount[npc.type] = 5;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) && NPC.downedBoss2 ? 0.1f : 0f;
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
            target.AddBuff(mod.BuffType("BCorrupt"), 180);
        }
    }
}
