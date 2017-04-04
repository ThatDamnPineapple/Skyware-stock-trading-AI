using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SpiritMod.NPCs.Spirit
{
    public class SpiritMimic : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Big Mimic";
            npc.displayName = "Spirit Mimic";
            npc.width = 17;
            npc.height = 21;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 3500;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 240000f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 87;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[475];
            aiType = NPCID.Zombie;
            animationType = 475;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int[] TileArray2 = { mod.TileType("SpiritDirt"), mod.TileType("SpiritStone"), mod.TileType("Spiritsand"), mod.TileType("SpiritGrass"), mod.TileType("SpiritIce"), };
            return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && NPC.downedMechBossAny && spawnInfo.spawnTileY > (Main.rockLayer + 150) ? 0.08f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, Vector2.Zero, 13);
                Gore.NewGore(npc.position, Vector2.Zero, 12);
                Gore.NewGore(npc.position, Vector2.Zero, 11);
            }
        }
        public override void NPCLoot()
        {
            string[] lootTable = { "SpiritFlameStaff", "Gravehunter","SpiritSword", "StoneOfSpiritsPast", };
            int loot = Main.rand.Next(lootTable.Length);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
        }
        private int Counter;
        public override void AI()
        {
            Counter++;
            if (Counter > 600)
            {
                int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ShadowMimic"), npc.whoAmI);
                Counter = 0;
            }
            {
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.05f, 0.4f);
            }
        }
    }
}