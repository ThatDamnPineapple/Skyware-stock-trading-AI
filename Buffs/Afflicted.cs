using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

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
            npc.GetModInfo<NInfo>(mod).afflicted = true;
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 257);
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, 206);
				Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 3f;
                Main.dust[dust1].scale = 3f;
            }
        }
    }
}