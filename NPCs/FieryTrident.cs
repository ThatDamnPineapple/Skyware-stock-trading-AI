using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class FieryTrident : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Fiery Trident";
            npc.displayName = "Fiery Trident";
            npc.width = 54;
            npc.height = 54;
            npc.damage = 70;
            npc.defense = 18;
            npc.lifeMax = 220;
            npc.soundHit = 4;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = .45f;
            npc.aiStyle = 23;
            aiType = NPCID.EnchantedSword;
            Main.npcFrameCount[npc.type] = 5;

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
        public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryPendant"));
            }
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 3f, 1f, 0.8f);

            npc.spriteDirection = npc.direction;

            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}
