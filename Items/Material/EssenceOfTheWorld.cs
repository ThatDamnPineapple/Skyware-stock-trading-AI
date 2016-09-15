using Terraria.ID;
using Terraria;
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
            item.maxStack = 999;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 50;
            item.scale = 0.6f;
        }
    }
}