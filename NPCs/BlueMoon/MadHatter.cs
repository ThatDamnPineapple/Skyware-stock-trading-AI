using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class MadHatter : ModNPC
    {
		int timer = 0;
		bool hat = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mad Hatter");
            Main.npcFrameCount[npc.type] = 15;
        }
        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 48;
            npc.damage = 30;
            npc.defense = 10;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 1000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            aiType = 104;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return MyWorld.BlueMoon ? 1f : 0f;
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
			if (timer % 300 >= 80)
			{
            npc.frameCounter += 0.40f;
            npc.frameCounter %= 13;
            int frame = (int)npc.frameCounter + 2;
            npc.frame.Y = frame * 80;
			}
			else if (timer % 300 < 40)
			{			
				npc.frame.Y = 80;
			}
			else
			{
				npc.frame.Y = 0;
			}
        }
        public override void AI()
        {
          npc.TargetClosest(true);
            Player player = Main.player[npc.target];
			timer++;
			if (timer % 300 == 40 && hat == false)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 15, 0, -7, mod.ProjectileType("MadHat"), 40, 1, Main.myPlayer, 0, 0);
				hat = true;
			}
			if (timer % 300 < 80)
			{
				
				if (player.position.X > npc.position.X)
				{
					npc.spriteDirection = 1;
					npc.netUpdate = true;
				}
				else
				{
					npc.spriteDirection = 0;
					npc.netUpdate = true;
				}
				
				npc.velocity.X = 0;
				
			}
			else
			{
				  npc.spriteDirection = npc.direction;
				  if (hat == true)
				hat = false;
				
			}
        }
        public override void NPCLoot()
        {
            
			if (Main.rand.Next(12) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 239);
            }
			if (Main.rand.Next(20) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MadHat"));
			}
        }
        
    }
}
