using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class EnergyFlux : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Granite Energy Flux";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss == false && Main.rand.Next(6) == 0)
            {
                npc.velocity.Y = -2;
            }
            if (npc.boss == false && Main.rand.Next(6) == 0)
            {
                npc.velocity.X = -2;
            }
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 187);      
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;		
            }
			}
        }
    }
