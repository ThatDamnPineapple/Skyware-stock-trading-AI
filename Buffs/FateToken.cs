using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace SpiritMod.Buffs
{
    public class FateToken : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Fate's Blessing";
            Main.buffTip[Type] = "You are protected by the Fates";
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			player.buffTime[buffIndex] = modPlayer.timeLeft;
        }
    }
}
