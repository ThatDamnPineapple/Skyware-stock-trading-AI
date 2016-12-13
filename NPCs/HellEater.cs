using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class HellEater : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Gluttonous Devourer";
            npc.displayName = "Gluttonous Devourer";
            npc.width = 48;
            npc.height = 34;
            npc.damage = 28;
            npc.defense = 16;
            npc.lifeMax = 90;
            npc.soundHit = 2;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 85;
            npc.noGravity = true;
            aiType = NPCID.StardustCellBig;
            Main.npcFrameCount[npc.type] = 4;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
            return oUnderworld && Main.hardMode ? 0.05f : 0f;
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

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}
