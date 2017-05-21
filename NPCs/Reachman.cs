using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SpiritMod.NPCs
{
    public class Reachman : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Reach Guard";
            npc.displayName = "Reach Guard";
            npc.width = 40;
            npc.height = 46;
            npc.damage = 14;
            npc.defense = 8;
            npc.lifeMax = 31;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 260f;
            npc.knockBackResist = .52f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.AngryBones;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneReach ? 2.7f : 0f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(15) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SanctifiedStabber"));
            }
         
            if (Main.rand.Next(2) == 1)
            {
                int Bark = Main.rand.Next(2) + 1;
                for (int J = 0; J <= Bark; J++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientBark"));
                }
            }
        
    }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Reach1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Reach2"), 1f);
            }
        }
    }
}
