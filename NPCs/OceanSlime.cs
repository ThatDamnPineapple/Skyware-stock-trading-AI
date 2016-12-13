using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class OceanSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Coconut Slime";
            npc.displayName = "Coconut Slime";
            npc.width = 18;
            npc.height = 14;
            npc.damage = 17;
            npc.defense = 9;
            npc.lifeMax = 60;
            npc.soundHit = 2;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .45f;
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
            return (tile == 53 || tile == 112 || tile == 116 || tile == 234) && spawnInfo.water && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
