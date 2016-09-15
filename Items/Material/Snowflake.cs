using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Snowflake : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frost Crystal";
            item.width = 22;
            item.height = 26;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 2;
        }
    }
}