using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class FrenzyVirus : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Frenzy Virus";
            Main.buffTip[Type] = "Reduces enemy defense by 8% and deals damage over time";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense = (npc.defDefense / 100) * 92;
            npc.lifeRegen -= 8;
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 173);
        }
    }
}
