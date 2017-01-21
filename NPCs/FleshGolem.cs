using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class FleshGolem : ModNPC
    {
        private float attackCool
        {
            get
            {
                return npc.ai[0];
            }
            set
            {
                npc.ai[0] = value;
            }
        }
        public override void SetDefaults()
        {
            npc.name = "Flesh Golem";
            npc.displayName = "Flesh Golem";
            npc.width = 70;
            npc.height = 84;
            npc.damage = 24;
            npc.defense = 12;
            npc.lifeMax = 345;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 20060f;
            npc.knockBackResist = .0f;
            npc.aiStyle = 3;
			aiType = NPCID.Skeleton;
			animationType = 415;
            Main.npcFrameCount[npc.type] = 8;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) ? 0.014f : 0f;
        }
 /*       public override void FindFrame(int frameHeight)
        {
            if (attackCool < 50f)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }*/
        public override void AI()
        {
			//npc.spriteDirection = npc.direction;
		//	npc.ai[0]++;
		//	if(npc.ai[0] % 8 == 0) {
		//		npc.frame.Y = (int)(npc.height * npc.frameCounter);
		//		npc.frameCounter = (npc.frameCounter + 1) % 8;
		//	}
            attackCool -= 1f;
        }
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(8,16);
		for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodFire"));
			}
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Butcher"));
            }
        }
		public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Flesh_Golem_Head"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Golem_Arm"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Golem_Arm"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Flesh_Golem_gore_1"), 1f);
			}
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("BCorrupt"), 180);
        }
    }
}
