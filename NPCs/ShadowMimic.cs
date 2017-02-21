using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class ShadowMimic : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shadow Mimic";
            npc.displayName = "Shadow Mimic";
            npc.width = 44;
            npc.height = 46;
            npc.damage = 33;
            npc.defense = 28;
            npc.lifeMax = 102;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 6060f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 25;
            aiType = NPCID.Mimic;
            Main.npcFrameCount[npc.type] = 5;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 53 || tile == 112 || tile == 116 || tile == 234) && spawnInfo.water && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) ? 0.5f : 0f;
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

            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 187);

            npc.spriteDirection = npc.direction;

        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 187);
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.Cursed, 180, true);
            }
        }
    }
}
