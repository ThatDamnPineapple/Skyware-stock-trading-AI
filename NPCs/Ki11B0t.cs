using Terraria;
using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Ki11B0t : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Ki11B0t";
            npc.displayName = "Ki11B0t";
            npc.width = 44;
            npc.height = 56;
            npc.damage = 29;
            npc.defense = 8;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = .95f;
           npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryBones];
            aiType = NPCID.AngryBones;
            animationType = NPCID.AngryBones;
        }
        public override void NPCLoot()
		{
			NPC.NewNPC((int)npc.position.X + Main.rand.Next(-30,30), (int)npc.position.Y, mod.NPCType("Ki11H3ad"));
			NPC.NewNPC((int)npc.position.X + Main.rand.Next(-30,30), (int)npc.position.Y, mod.NPCType("Ki11H3ad"));
			NPC.NewNPC((int)npc.position.X + Main.rand.Next(-30,30), (int)npc.position.Y, mod.NPCType("Ki11H3ad"));
		}
    }
}
