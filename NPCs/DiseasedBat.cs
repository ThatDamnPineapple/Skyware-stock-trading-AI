using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class DiseasedBat : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Diseased Bat";
            npc.displayName = "Diseased Bat";
            npc.width = 26;
            npc.height = 18;
            npc.damage = 17;
            npc.defense = 5;
            npc.lifeMax = 44;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath4;
            npc.value = 60f;
            npc.knockBackResist = .5f;
            npc.aiStyle = 14;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CaveBat];
            aiType = NPCID.CaveBat;
            animationType = NPCID.CaveBat;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
        	
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && y > Main.rockLayer ? 0.25f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DBat1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Dbat2"), 1f);
            }
        }

        public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BismiteCrystal"), Main.rand.Next(3) + 2);
		}

	}
}
