using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Artifact
{
    public class Blaze1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blaze");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod).blaze1 = true;
            {
                int num2 = Dust.NewDust(npc.position, npc.width, npc.height, 244);
                Main.dust[num2].scale = 5.9f;
                Main.dust[num2].velocity *= 1f;
                Main.dust[num2].noGravity = true;
            }
            if (Main.rand.Next(20) == 0)
            {
                {
                    for (int i = 0; i < 40; i++)
                    {
                        int num = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, -2f, 0, default(Color), 2f);
                        Main.dust[num].noGravity = true;
                        Dust expr_62_cp_0 = Main.dust[num];
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("Fire"), 20, 0, Main.myPlayer, 0, 0);
                        {
                            expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                            Dust expr_92_cp_0 = Main.dust[num];
                            expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                            if (Main.dust[num].position != npc.Center)
                            {
                                Main.dust[num].velocity = npc.DirectionTo(Main.dust[num].position) * 6f;
                            }
                        }
                    }
                }
            }
        }
    }
}
