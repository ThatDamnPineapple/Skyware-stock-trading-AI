using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class LunarSlime : ModNPC
    {
		bool jump = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunar Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 26;
            npc.damage = 55;
            npc.defense = 12;
            npc.lifeMax = 160;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath22;
            npc.value = 60f;
            npc.knockBackResist = .6f;
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return MyWorld.BlueMoon ? 5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
		
		public override bool PreAI()
		  {
			  if (npc.collideY && jump)
			  {
				  if (Main.rand.Next(4) == 0)
				  {
				  Projectile.NewProjectile(npc.position.X, npc.position.Y - 500, 0, 4, mod.ProjectileType("LunarStar"), 45, 1, Main.myPlayer, 0, 0);
				  }
				  jump = false;
				   for (int i = 0; i < 10; i++)
                {
                    int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                }
			  }
			  if (!npc.collideY)
			{
				jump = true;
			}
			return true;
		  }
		  
		 public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoonJelly"));
            }
        }
		

	}
}
