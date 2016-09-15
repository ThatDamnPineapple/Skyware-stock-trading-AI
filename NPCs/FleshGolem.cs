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
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .0f;
            npc.aiStyle = 3;
			aiType = NPCID.Skeleton;
			animationType = 415;
            Main.npcFrameCount[npc.type] = 8;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) ? 0.1f : 0f;
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
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("BCorrupt"), 180);
        }
    }
}
