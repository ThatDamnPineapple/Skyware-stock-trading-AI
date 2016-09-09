using Microsoft.Xna.Framework;
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
            item.damage = 39;   
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 35;
            item.useAnimation = 30;
            item.axe = 16;
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