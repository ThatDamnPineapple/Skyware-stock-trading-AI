using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class PinkJelly : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Man O' War";
            npc.displayName = "Man O' War";
            npc.width = 44;
            npc.height = 40;
            npc.damage = 80;
            npc.defense = 28;
            npc.lifeMax = 120;
            npc.HitSound = SoundID.NPCHit25;
            npc.DeathSound = SoundID.NPCDeath28;
            npc.value = 6060f;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            npc.aiStyle = 18;
            aiType = NPCID.BlueJellyfish;
            Main.npcFrameCount[npc.type] = 4;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 53 || tile == 112 || tile == 116 || tile == 234) && spawnInfo.water && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) ? 0.5f : 0f;
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
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 3f, 1f, 0.8f);

            npc.spriteDirection = npc.direction;

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180, true);
            }
        }
    }
}
