using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class ArcaneGeyser : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Arcane Geyser";
            item.width = item.height = 16;
            item.maxStack = 999;
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 15, 0);
        }
    }
}
