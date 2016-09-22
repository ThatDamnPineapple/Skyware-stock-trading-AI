using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Scarebus
{
    public class Scarebus : ModNPC
    {
		//ai 1 = current action
		//ai 2 = speed multiplier thingie
		//ai 3 = for timer for speed
		//ai 0 for vertical speed
		private int SpeedMax = 80;
		private int SpeedDistanceIncrease = 100;
        public override void SetDefaults()
        {
            npc.name = "Scarebus";
            npc.width = 90;
            npc.height = 172;

            npc.damage = 21;
            npc.defense = 15;
            npc.lifeMax = 1400;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.npcSlots = 10;

            //npc.soundHit = 7;
            //npc.soundKilled = 5;

            //Main.npcFrameCount[npc.type] = 6; iunno
        }
		private int Counter;
        public override bool PreAI()
        {
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			
			//spawning beetles
			Counter++;
            if (Counter > 180)
            {
				int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Scarab"), npc.whoAmI);
				Counter = 0;
            }
			
			//charging, distance increases speed
			if (npc.ai[1] == 0)
			{
					if (npc.Center.X >= player.Center.X && npc.ai[2] >= (0 - SpeedMax)) // moves to players x position
				{
					for (npc.ai[3] = 0; npc.ai[3] < Math.Abs(npc.Center.X - player.Center.X); npc.ai[3] = npc.ai[3] + SpeedDistanceIncrease)
					{
					npc.ai[2]--;
					}
					npc.ai[2]--;
				}
					
				if (npc.Center.X <= player.Center.X && npc.ai[2] <= SpeedMax)
				{
					for (npc.ai[3] = 0; npc.ai[3] < Math.Abs(npc.Center.X - player.Center.X); npc.ai[3] = npc.ai[3] + SpeedDistanceIncrease)
					{
					npc.ai[2]++;
					}
					npc.ai[2]++;
				}
				npc.noGravity = false;
				npc.noTileCollide = false;
				npc.velocity.X = npc.ai[2] * 0.1f;
				
			}
			
			//flying towards the player
			if (npc.ai[1] == 1)
			{
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[0]--;
				if (npc.Center.X >= player.Center.X && npc.ai[2] >= 0 - SpeedMax * 1.3) // flies to players x position
				{
					npc.ai[2]--;
					npc.ai[2]--;
				}
					
				if (npc.Center.X <= player.Center.X && npc.ai[2] <= SpeedMax * 1.3)
				{
					npc.ai[2]++;
					npc.ai[2]++;
				}
				npc.velocity.Y = npc.ai[0] * 0.1f;
				npc.velocity.X = npc.ai[2] * 0.1f;
				if (Math.Abs(npc.Center.X - player.Center.X) < 30)
				{
					npc.velocity.Y = 0;
				npc.velocity.X = 0;
					npc.ai[0] = 0;
				npc.ai[2] = 0;
				npc.ai[3] = 0;
					npc.ai[1] = 2;
				}
			}
			
			//stomping
			if (npc.ai[1] == 2)
			{
				npc.velocity.X = 0;
				npc.noGravity = false;
				npc.noTileCollide = false;
				npc.ai[0]++;
				npc.velocity.Y = npc.ai[0] * 0.2f;
				if (Math.Abs(npc.Center.Y - player.Center.Y) < 70)
				{
					npc.velocity.Y = 0;
				npc.velocity.X = 0;
					npc.ai[0] = 0;
				npc.ai[2] = 0;
				npc.ai[3] = 0;
					npc.ai[1] = 0;
				}
			}
			string SlopeText = npc.ai[1].ToString();
				Main.NewText(SlopeText, Color.Orange.R, Color.Orange.G, Color.Orange.B);
			//deciding on AI
			if ((Math.Abs(npc.Center.X - player.Center.X) > 600 || Main.rand.Next(310) == 2 ) && npc.ai[1] == 0)
			{
				npc.velocity.Y = 0;
				npc.velocity.X = 0;
				npc.ai[0] = 0;
				npc.ai[2] = 0;
				npc.ai[3] = 0;
				npc.ai[1] = 1;
			}
			
            return true;
			
        }

      /*  public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 5)
            {
                npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
                npc.frameCounter = 0;
            }
        }*/
    }
}
