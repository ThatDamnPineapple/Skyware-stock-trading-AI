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
    public class StarFracture : ModBuff
    {
        private int npcDefenseBegin;
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Star Fracture";
			Main.buffTip[Type] = "Your armor is worse";
            Main.pvpBuff[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetModInfo<NPCData>(mod).sFracture = true;
            npc.defense -= 4;
        }
        
    }
}