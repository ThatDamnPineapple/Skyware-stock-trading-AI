using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Scarabeus
{
    public class Scarabeus : ModNPC
    {
		//ai 1 = current action
		//ai 2 = speed multiplier thingie
		//ai 3 = for timer for speed
		//ai 0 for vertical speed
		private int SpeedMax = 30;
		private int SpeedDistanceIncrease = 500;
        public override void SetDefaults()
        {
            npc.name = "Scarabeus";
            npc.width = 100;
            npc.height = 60;
			bossBag = mod.ItemType("BagOScarabs");

            npc.damage = 21;
            npc.defense = 15;
            npc.lifeMax = 1100;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.npcSlots = 10;
			Main.npcFrameCount[npc.type] = 6;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
        }
		private int Counter;
        public override bool PreAI()
        {
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			
			//spawning beetles
			Counter++;
            if (Counter > 250)
            {
				int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Scarab"), npc.whoAmI);
				Counter = 0;
            }
			
			//charging, distance increases speed
			if (npc.ai[1] == 0)
			{
					if (npc.Center.X >= player.Center.X && npc.ai[2] >= (0 - SpeedMax)) // moves to players x position
				{
					for (npc.ai[3] = 0; npc.ai[3] < Math.Abs(npc.Center.X - player.Center.X); npc.ai[3] = npc.ai[3] + SpeedDistanceIncrease) //acceleration increases with distance away
					{
					npc.ai[2]--;
					}
					npc.ai[2]--;
				}
					
				if (npc.Center.X <= player.Center.X && npc.ai[2] <= SpeedMax)
				{
					for (npc.ai[3] = 0; npc.ai[3] < Math.Abs(npc.Center.X - player.Center.X); npc.ai[3] = npc.ai[3] + SpeedDistanceIncrease) //acceleration increases with distance away
					{
					npc.ai[2]++;
					}
					npc.ai[2]++;
				}
				if (npc.ai[0] < 100)
				{
				npc.ai[0]++;
				npc.ai[0]++;
				}
				npc.noGravity = false;
				npc.noTileCollide = false;
				if (Main.rand.Next(2) > 0)
				{
				npc.velocity.X = npc.ai[2] * 0.1f;
				}
				npc.velocity.Y = npc.ai[0] * 0.26f;
				if (npc.velocity.X == 0 && Main.rand.Next(3) == 1)
				{
					npc.ai[0] = -40;
					npc.noTileCollide = true;
					
				}
				if (Main.expertMode && Main.rand.Next(20) == 1)
			{
				if (npc.velocity.X < 0)
				{
				Projectile.NewProjectile(npc.position.X, npc.Center.Y, Main.rand.Next(2,5), Main.rand.Next(-4,4), mod.ProjectileType("ScarabDust"), 12, 0f, player.whoAmI, 0f, 0f);
				}
				if (npc.velocity.X > 0)
				{
				Projectile.NewProjectile(npc.position.X, npc.Center.Y, Main.rand.Next(-5,-2), Main.rand.Next(-4,4), mod.ProjectileType("ScarabDust"), 12, 0f, player.whoAmI, 0f, 0f);
			}
			}
				
			}
			
			//flying towards the player
			if (npc.ai[1] == 1)
			{
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[0]++;
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
				npc.velocity.Y = npc.ai[0] * 0.08f;
				npc.velocity.X = npc.ai[2] * 0.1f;
				if (Math.Abs(npc.Center.X - player.Center.X) < 40)
				{
					npc.velocity.Y = 0;
				npc.velocity.X = 0;
					npc.ai[0] = 0;
				npc.ai[2] = 0;
				npc.ai[3] = 0;
					npc.ai[1] = 2;
				}
				if (npc.ai[0] > 0)
				{
					
				npc.ai[3] = 0;
					npc.ai[1] = 0;
				}
			}
			
			//stomping
			if (npc.ai[1] == 2)
			{
				npc.velocity.X = 0;
				npc.noGravity = false;
				npc.noTileCollide = false;
				npc.ai[0]++;
				npc.ai[0]++;
				npc.ai[0]++;
				npc.velocity.Y = npc.ai[0] * 0.2f;
				if (Math.Abs(npc.Center.Y - player.Center.Y) < 70)
				{
				npc.velocity.X = 0;
				npc.ai[2] = 0;
				npc.ai[3] = 0;
					npc.ai[1] = 0;
				}
			}
			//deciding on AI
			if ((Math.Abs(npc.Center.X - player.Center.X) > 700 || Main.rand.Next(410) == 2 ) && npc.ai[1] == 0)
			{
				npc.velocity.Y = 0;
				npc.velocity.X = 0;
				npc.ai[0] = -120;
				npc.ai[3] = 0;
				npc.ai[1] = 1;
			}
			
            return true;
			
        }
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chitin"), Main.rand.Next(25,36));
				string[] lootTable = {"ScarabBow"};
				int loot = Main.rand.Next(lootTable.Length);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                if (Main.rand.Next(100) <= 50)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,(mod.ItemType("OrnateStaff")),Main.rand.Next(1,5));
				}
			}
		}
			public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
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
