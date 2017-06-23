using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Artifact
{
    public class KingslayerVenom : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Kingslayer Venom");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense = (npc.defDefense / 100) * 85;
            npc.damage = (npc.defDamage / 100) * 80;

            Dust.NewDust(npc.position, npc.width, npc.height, 110);
        }
    }
}
