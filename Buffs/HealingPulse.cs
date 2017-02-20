using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class HealingPulse : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Healing Pulse";
			Main.buffTip[Type] = "Heals enemies";
            Main.pvpBuff[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense += 4;
            npc.lifeRegen += 8;
            int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 74, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);

        }
    }
}