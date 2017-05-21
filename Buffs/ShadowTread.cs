using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class ShadowTread : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Shadow Tread";
            Main.buffTip[Type] = "'Become the shadow' \n Increases movement speed and acceleration";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.maxRunSpeed += 0.12f;
            player.runAcceleration += 0.12f;
            {

                Dust.NewDust(player.position, player.width, player.height, 62);
            }
        }
    }
}
