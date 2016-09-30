using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class HardenedCarpace : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Hardened Carpace";
            item.width = 26;
            item.height = 22;
            item.value = 50;

            item.maxStack = 999;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
        }

    }
}