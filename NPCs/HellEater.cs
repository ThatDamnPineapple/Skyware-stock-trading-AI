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
            npc.lifeMax = 82;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 3060f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 85;
            npc.noGravity = true;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Pixie];
            aiType = NPCID.StardustCellBig;
            animationType = NPCID.Pixie;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            bool oUnderworld = (y >= (Main.maxTilesY * 0.4f));
            return oUnderworld && NPC.downedBoss3 ? 0.08f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EaterGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EaterGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EaterGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EaterGore2"), 1f);
            }
        }

        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.08f, 0.04f, 0.2f);

            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CarvedRock"), Main.rand.Next(1) + 2);
            }
        }
    }
}
