using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Alien : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Alien";
            npc.displayName = "Alien";
            npc.width = 24;
            npc.height = 44;
            npc.damage = 70;
            npc.defense = 30;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 10000f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 26;
            aiType = NPCID.Unicorn;
            Main.npcFrameCount[npc.type] = 8;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.eclipse && NPC.downedMechBoss2 && NPC.downedMechBoss1 && NPC.downedMechBoss3 ? 0.07f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.40f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ToxicExtract"));
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 1)
            {
                target.AddBuff(BuffID.Venom, 160);
            }
        }
    }
}
