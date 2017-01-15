using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Material
{
    public class TidalEssence : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tidal Essence";
            item.width = item.height = 16;
            item.toolTip = "The Essence of Beasts from the Deep";
            item.maxStack = 999;
            item.rare = 5;

            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(5, 4);
        }
    }
}
