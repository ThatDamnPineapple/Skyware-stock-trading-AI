using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;


namespace SpiritMod.NPCs
{
    public class ShootingStar : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shooting Star";
            npc.displayName = "Shooting Star";
            npc.width = 24;
            npc.height = 30;
            npc.damage = 50;
            npc.defense = 20;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 5060f;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 56;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.ChaosBall];
            aiType = NPCID.DungeonSpirit;
            animationType = NPCID.ChaosBall;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky && Main.hardMode && NPC.downedMechBossAny ? 0.3f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			 if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 13);
                Gore.NewGore(npc.position, npc.velocity, 12);
                Gore.NewGore(npc.position, npc.velocity, 11);
				Gore.NewGore(npc.position, npc.velocity, 13);
                Gore.NewGore(npc.position, npc.velocity, 12);
                Gore.NewGore(npc.position, npc.velocity, 11);

                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 160);
            }
        }
        public override void NPCLoot()
		{
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarPiece"), Main.rand.Next(1) + 1);
			}
		}
    }
}
