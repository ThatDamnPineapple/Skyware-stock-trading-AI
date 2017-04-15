using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class Death : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Death";
            Main.buffTip[Type] = "You dead";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss == false)
            {
                npc.GetModInfo<NInfo>(mod).Death = true;
            }
        }
    }
}
