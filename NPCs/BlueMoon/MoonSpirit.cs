using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class MoonSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Spirit");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 34;
            npc.damage = 55;
            npc.defense = 10;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 1000f;
			 npc.noGravity = true;
            npc.noTileCollide = true;
			npc.aiStyle = 22;
            aiType = NPCID.Wraith;
            npc.knockBackResist = 0.25f;
           

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return MyWorld.BlueMoon ? 4f : 0f;
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
		 public override bool PreAI()
		  {
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();
			if (Main.rand.Next(10) == 1)
			{
			 int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
			}
            if (Main.rand.Next(800) == 1)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Sparkle"), 0, 2, 1, 0, npc.whoAmI, npc.target);
					}
            return true;

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
