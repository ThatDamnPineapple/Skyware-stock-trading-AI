using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Artifact
{
    public class DeathWreathe3 : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Soul Wreathe");
            Main.pvpBuff[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss == false)
            {
                if (!npc.friendly)
                {
                    npc.damage = (npc.defDamage / 100) * 70;
                    int d = Dust.NewDust(npc.position, npc.width, npc.height, 110);
                    Main.dust[d].scale *= 2f;
                    Main.dust[d].velocity *= 0f;
                    Main.dust[d].noGravity = true;
                }
                if (!npc.friendly)
                {
                    if (npc.life <= 10)
                    {
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("Necromancer"), 60, 0, Main.myPlayer, 0, 0);

                        }
                    }
                }
            }
        }        
    }
}