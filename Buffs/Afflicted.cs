using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class Afflicted : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Unstable Affliction";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.Next(2) == 0)
            {
                npc.lifeRegen -= 6;
            }
            else
            {
                npc.defense -= 5;
            }

            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 257);
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
				Main.dust[dust].noGravity = true;		
            }
        }
    }
}