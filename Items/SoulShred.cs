using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items
{
    public class SoulShred : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }


        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Heart);
            item.rare = 5;
            item.width = 14;
            item.healLife = 25;
            item.height = 36;
        }
    }
}