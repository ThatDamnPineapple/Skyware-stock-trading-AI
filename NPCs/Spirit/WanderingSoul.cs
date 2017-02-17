using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs.Spirit
{
    public class WanderingSoul : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Wandering Soul";
            npc.displayName = "Wandering Soul";
            npc.width = 17;
            npc.height = 24;
            npc.damage = 46;
            npc.defense = 40;
            npc.lifeMax = 540;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 22;
            aiType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
            aiType = NPCID.Wraith;
            animationType = NPCID.Wraith;
            npc.stepSpeed = .5f;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int[] TileArray2 = { mod.TileType("SpiritDirt"), mod.TileType("SpiritStone"), mod.TileType("Spiritsand"), mod.TileType("SpiritGrass"), mod.TileType("SpiritIce"), };
            return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && spawnInfo.spawnTileY < Main.rockLayer ? 10f : 0f;
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

        public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 1)
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Rune"));
		}

	}
}