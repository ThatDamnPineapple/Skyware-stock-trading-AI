using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class ShadowAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Possessed Battleaxe";
            item.width = 46;
            item.height = 46;
            item.value = 10000;
            item.rare = 4;

            item.axe = 16;

            item.damage = 39;
            item.knockBack = 6;

            item.useStyle = 1;
            item.useTime = 35;
            item.useAnimation = 30;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.useSound = 1;
        }
    }
}