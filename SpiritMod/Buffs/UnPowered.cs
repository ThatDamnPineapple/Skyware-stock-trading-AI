using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class UnPowered : ModBuff
    {


        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[Type] = "Un Powered";
            Main.debuff[Type] = true;
            Main.buffTip[Type] = "Cannot use the Darkfire Katanas Special Ability";
        }
    }
}