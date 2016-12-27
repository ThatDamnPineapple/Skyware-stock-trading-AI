using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using SpiritMod.NPCs;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class EssenceTrap : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Essence Trap";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 10;
            npc.defense -= 4;
            npc.GetModInfo<NInfo>(mod).Etrap = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 67);                
            }
        }
    }
}