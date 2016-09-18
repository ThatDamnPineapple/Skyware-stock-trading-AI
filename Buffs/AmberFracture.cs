using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class AmberFracture : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Amber Fracture";
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            info.amberFracture = true;
        }
    }
}
