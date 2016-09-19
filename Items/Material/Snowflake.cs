using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Snowflake : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Snowflake";
            item.width = 22;
            item.height = 26;
            item.value = 100;
            item.rare = 2;

            item.maxStack = 999;
        }
    }
}