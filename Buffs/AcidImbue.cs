using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class AcidImbue : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] =  "Acid Imbue";
            Main.buffTip[Type] = "Throwing attacks occasionally inflict Acid Burn";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            modPlayer.acidImbue = true;

        }
    }
}
