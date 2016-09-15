using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Sharkon : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Sharkon";
            npc.displayName = "Sharkon";
            npc.width = 118;
            npc.height = 42;
            npc.damage = 70;
            npc.defense = 12;
            npc.lifeMax = 600;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .55f;
            npc.aiStyle = 16;
            npc.noGravity = true;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
            aiType = NPCID.Shark;
            animationType = NPCID.Shark;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (tile == 53 || tile == 112 || tile == 116 || tile == 234) &&  spawnInfo.water && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
