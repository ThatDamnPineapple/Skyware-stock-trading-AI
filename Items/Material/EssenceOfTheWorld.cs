using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class EssenceOfTheWorld : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Essence of the World";
            item.width = 30;
            item.height = 30;
            item.value = 50;

            item.scale = 0.6f;
            item.maxStack = 999;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
        }
    }
}