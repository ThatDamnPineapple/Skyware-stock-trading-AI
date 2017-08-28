using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class Werebunny : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wererabbit");
            Main.npcFrameCount[npc.type] = 14;
        }
        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 56;
            npc.damage = 45;
            npc.defense = 10;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 1000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            aiType = NPCID.Unicorn;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return MyWorld.BlueMoon ? 10f : 0f;
        }
       /* public override void HitEffect(int hitDirection, double damage)
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
        }*/
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
           /* if (Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ToxicExtract"));
            }*/
        }
        
    }
}
