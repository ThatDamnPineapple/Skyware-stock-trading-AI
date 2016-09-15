using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class DElemental : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Demomite Elemental";
            npc.displayName = "Demomite Elemental";
            npc.width =30;
            npc.height = 32;
            npc.damage = 28;
            npc.defense = 13;
            npc.lifeMax = 55;
            npc.soundHit = 7;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = .45f;
            npc.aiStyle = 91;
            aiType = NPCID.GraniteFlyer;
            Main.npcFrameCount[npc.type] = 10;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 25) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
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
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.08f, 0.04f, 0.2f);

            npc.spriteDirection = npc.direction;
        }
    }
}
