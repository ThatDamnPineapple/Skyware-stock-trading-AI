using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class ShadowHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Possessed Warhammer";
            item.damage = 46;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.useTime = 37;
            item.useAnimation = 30;
            item.hammer = 80;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
        }
    }
}