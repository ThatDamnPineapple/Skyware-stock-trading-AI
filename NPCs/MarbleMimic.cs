using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class MarbleMimic : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Big Mimic";
            npc.displayName = "Marble Mimic";
            npc.width = 17;
            npc.height = 21;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 3500;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 87;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[475];
            aiType = NPCID.Zombie;
            animationType = 475;
        }
		public override void NPCLoot()
		{
			string[] lootTable = { "TatteredShotbow", "GoldenApple", "ZeusLightning", "CircleScimitar"};
			int loot = Main.rand.Next(lootTable.Length);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
		}
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return  (tile == 367) && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.05f : 0f;
        }
    }
}
