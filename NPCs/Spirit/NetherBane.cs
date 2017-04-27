using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SpiritMod.NPCs.Spirit
{
    public class NetherBane : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Netherbane";
            npc.displayName = "Netherbane";
            npc.width = 64;
            npc.height = 62;
            npc.damage = 44;
            npc.defense = 19;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = .35f;
            npc.aiStyle = 14;
            npc.noTileCollide = true;
            aiType = NPCID.CaveBat;
            Main.npcFrameCount[npc.type] = 4;
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
            int[] TileArray2 = { mod.TileType("SpiritDirt"), mod.TileType("SpiritStone"), mod.TileType("Spiritsand"), mod.TileType("SpiritGrass"), };
            return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && NPC.downedMechBossAny ? .5f : 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.05f, 0.4f);
            {
                npc.spriteDirection = npc.direction;
            }
        }
    }
}
