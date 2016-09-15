using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Rune : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ancient Rune";
            item.width = 38;
            item.height = 42;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 4;
        }
    }
}