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
            npc.soundHit = 1;
            npc.soundKilled = 4;
            npc.value = 60f;
            npc.knockBackResist = .20f;
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
            return (tile == 1) && y > Main.rockLayer ? 0.2f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BismiteCrystal"), Main.rand.Next(3) + 2);
		}

	}
}
