using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace SpiritMod.Items.Material
{
    public class StarEnergy : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Energized Metal";
            item.toolTip = "'It uses some kind of otherworldly power source'";
            item.width = 38;
            item.height = 42;
            item.value = 100;
            item.rare = 3;
            item.maxStack = 999;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
