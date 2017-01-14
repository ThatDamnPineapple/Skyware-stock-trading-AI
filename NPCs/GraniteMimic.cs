using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class GraniteMimic : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Big Mimic";
            npc.displayName = "Granite Mimic";
            npc.width = 17;
            npc.height = 21;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 3500;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 87;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[475];
            aiType = NPCID.Zombie;
            animationType = 475;
        }
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 13);
                Gore.NewGore(npc.position, npc.velocity, 12);
                Gore.NewGore(npc.position, npc.velocity, 11);
            }
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return  (tile == 368) && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.05f : 0f;
        }
        public override void NPCLoot()
        {
            string[] lootTable = { "LazureLongbow", "GraniteShield", "GraniteReflector"};
            int loot = Main.rand.Next(lootTable.Length);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
        }
    }
}
