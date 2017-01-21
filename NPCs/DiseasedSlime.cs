using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class DiseasedSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Diseased Slime";
            npc.displayName = "Diseased Slime";
            npc.width = 44;
            npc.height = 32;
            npc.damage = 40;
            npc.defense = 12;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath22;
            npc.value = 60f;
            npc.knockBackResist = .4f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
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
