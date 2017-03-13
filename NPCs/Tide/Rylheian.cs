using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tide
{
    public class Rylheian : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;
        float HomeY = 150f;

        public override void SetDefaults()
        {
            npc.name = "R'lyheian";
            npc.width = 80;
            npc.height = 100;
            npc.damage = 46;
            npc.lifeMax = 3000;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 44;
            aiType = NPCID.FlyingAntlion;

            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;
        }
        private int Counter;
        public override bool PreAI()
        {
            {
                Counter++;
                if (Counter > 400)
                {
                    int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Tentacle"), npc.whoAmI);
                    Counter = 0;
                }
            }
                timer++;
                if (timer == 200 || timer == 250 || timer == 300 || timer == 350 || timer == 400 || timer == 450)
                {
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 5f;
                    direction.Y *= 5f;

                    int amountOfProjectiles = Main.rand.Next(5, 6);
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-150, 150) * 0.03f;
                        float B = (float)Main.rand.Next(-150, 150) * 0.03f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("WitherBolt"), 28, 1, Main.myPlayer, 0, 0);
                    }
                }
                if (timer >= 500)
                {
                    timer = 0;
                }
            return true;
        }

        public override void NPCLoot()
        {
            {
                string[] lootTable = { "CthulhuStaff2", "CthulhuStaff1"};
                int loot = Main.rand.Next(lootTable.Length);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
            }
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
            if (InvasionWorld.invasionType == SpiritMod.customEvent && Main.hardMode)
                return 0.05f;

            return 0;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 173);
            npc.spriteDirection = npc.direction;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Tentacle"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TentacleHead"), 1f);
            }
        }
    }
}
   