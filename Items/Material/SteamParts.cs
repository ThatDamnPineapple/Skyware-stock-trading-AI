using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class SteamParts : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Starplate Fragments";
            item.toolTip = "'Powered by celestial energy'";
            item.width = 42;
            item.height = 24;
            item.value = 800;
            item.rare = 3;

            item.maxStack = 999;
        }
    }
}
