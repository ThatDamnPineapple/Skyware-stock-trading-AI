using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class FelBrand : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Fel Brand";
            Main.buffTip[Type] = "Attack decreased, and damage per second";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage = (int)(npc.damage * 0.92f);
            npc.GetModInfo<NInfo>(mod).felBrand = true;
        }
    }
}
