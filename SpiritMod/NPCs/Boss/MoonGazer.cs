using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class MoonGazer : ModNPC
    {
        int timer = 0;

        public override void SetDefaults()
        {
            npc.name = "True Blood Gazer";
            npc.width = 50;
			npc.aiStyle = -1;
            npc.height = 68;
            npc.damage = 50;
            npc.defense = 13;
            npc.lifeMax = 1500;
            npc.knockBackResist = 0;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5;
            npc.soundHit = 7;
            npc.soundKilled = 5;
            Main.npcFrameCount[npc.type] = 7;
			npc.scale = 1.3f;
        }

        public override void AI()
        {
			timer++;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (timer == 50)
			{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					npc.velocity.Y = direction.Y * 10f;
					npc.velocity.X = direction.X * 10f;
					timer = 0;
			}
				if (timer == 40)
			{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					npc.velocity.Y = direction.Y * 1f;
					npc.velocity.X = direction.X * 1f;
			}
        }
		
							public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(10,26);
		for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Veinstone"));
			}
		}
    }
}
