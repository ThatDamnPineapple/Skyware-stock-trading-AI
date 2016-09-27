using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Atlas
{
    public class Atlas : ModNPC
    {
        // npc.ai[0] = state manager.

        int[] arms = new int[2];

        public override void SetDefaults()
        {
            npc.name = "Atlas";
            npc.width = 80;
            npc.height = 160;

            npc.damage = 22;
            npc.lifeMax = 4600;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;

            npc.alpha = 255;
        }

        public override bool PreAI()
        {           
            if(npc.ai[0] == 0) // First frame update.
            {
                npc.dontTakeDamage = true;

                arms[0] = NPC.NewNPC((int)npc.Center.X - 80 - Main.rand.Next(80, 160), (int)npc.position.Y, mod.NPCType("AtlasArm"), npc.whoAmI, 0, 0, 0, -1);
                arms[1] = NPC.NewNPC((int)npc.Center.X + 80 + Main.rand.Next(80, 160), (int)npc.position.Y, mod.NPCType("AtlasArm"), npc.whoAmI, 0, 0, 0, 1);

                npc.ai[0] = 1;
            }
            else if(npc.ai[0] == 1) // Spawn sequence (appearing).
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 210)
                {
                    npc.alpha -= 4;
                    if (npc.alpha <= 0)
                    {
                        npc.ai[0] = 2;
                        npc.ai[1] = 0;

                        npc.alpha = 0;
                        npc.velocity.Y = 14;
                        npc.dontTakeDamage = false;
                    }
                }
            }
            else if(npc.ai[0] == 2)
            {
                npc.velocity.Y -= 0.2F;
                if(npc.velocity.Y < 0)
                {
                    npc.velocity = Vector2.Zero;

                    Main.npc[arms[0]].ai[0] = 2;
                    Main.npc[arms[1]].ai[0] = 2;
                }
            }

            return false;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (npc.ai[0] < 2)
                return false;

            return base.CanHitPlayer(target, ref cooldownSlot);
        }
    }
}
