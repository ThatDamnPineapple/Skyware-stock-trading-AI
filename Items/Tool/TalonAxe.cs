using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class TalonAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Talon Axe";
            item.width = 46;
            item.height = 46;
            item.value = 10000;
            item.rare = 4;

            item.axe = 26;

            item.damage = 15;
            item.knockBack = 6;

            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.useSound = 1;
        }
    }
}