/*using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tide
{
    public class KrakamoraSphere : ModNPC
    {
        int timer = 0;

        public override void SetDefaults()
        {
            npc.name = "Kakamoran Portal";
            npc.width = 80;
            npc.height = 80;
            npc.alpha = 255;

            npc.defense = 999;
            npc.lifeMax = 100;
            npc.knockBackResist = 0;

            npc.friendly = false;
            npc.dontTakeDamage = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;

            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
        }
        public override bool PreAI()
        {
            npc.velocity *= 0f;
            {
                timer++;
                if (timer == 200)
                {
                    int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Kakamora1"), npc.whoAmI);
                    npc.dontTakeDamage = false;
                }
                if (timer == 400)
                {
                    int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Kakamora2"), npc.whoAmI);
                }
                if (timer >= 400)
                {
                    timer = 0;
                }
            }
            if (npc.target == 255)
            {
                npc.TargetClosest(true);
                float num1 = 6f;
                Vector2 vector2 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                float num2 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector2.X;
                float num3 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector2.Y;
                float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                float num5 = num1 / num4;
                npc.velocity.X = num2 * num5;
                npc.velocity.Y = num3 * num5;
            }
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
                Main.dust[dust2].scale = 5f;
                Main.dust[dust1].scale = 5f;
                Main.dust[dust].scale = 5f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
            }

            if (npc.timeLeft > 100)
                npc.timeLeft = 100;

            return false;
        }
        public virtual bool CheckActive(NPC npc)
        {
            return false;
        }
        public override void NPCLoot()
        { 
            InvasionWorld.invasionSize -= 1;
            if (InvasionWorld.invasionSize < 0)
                InvasionWorld.invasionSize = 0;
            if (Main.netMode != 1)
                InvasionHandler.ReportInvasionProgress(InvasionWorld.invasionSizeStart - InvasionWorld.invasionSize, InvasionWorld.invasionSizeStart, 0);
            if (Main.netMode != 2)
                return;
            NetMessage.SendData(78, -1, -1, "", InvasionWorld.invasionProgress, (float)InvasionWorld.invasionProgressMax, (float)Main.invasionProgressIcon, 0.0f, 0, 0, 0);
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            if (InvasionWorld.invasionType == SpiritMod.customEvent && Main.hardMode && !NPC.AnyNPCs(mod.NPCType("KrakamoraSphere")))
                return .3f;

            return 0;
        }
    }
}*/
