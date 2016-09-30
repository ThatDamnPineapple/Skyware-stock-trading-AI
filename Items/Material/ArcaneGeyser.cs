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
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 4;

            item.maxStack = 999;
        }
    }
}