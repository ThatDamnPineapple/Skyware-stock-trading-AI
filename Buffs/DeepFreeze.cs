using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class DeepFreeze : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Deep Freeze";
			Main.buffTip[Type] = "You are frozen solid!";
			
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity.X = 0;
			npc.velocity.Y = 0;
        }
				public override void Update(Player player, ref int buffIndex)
		{
			 player.velocity.X = 0;
			player.velocity.Y = 0;
		}

    }
}