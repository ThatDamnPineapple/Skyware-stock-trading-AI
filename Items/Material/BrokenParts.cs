using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class BrokenParts : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Broken Gun Parts";
            item.width = 24;
            item.height = 28;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 8;

            item.maxStack = 999;
        }
    }
}