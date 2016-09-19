using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Material
{
    public class FieryEssence : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fiery Essence";
            item.width = item.height = 16;
            item.toolTip = "The Essence of the Malevolent";
            item.maxStack = 999;
            item.rare = 8;

            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(5, 4);
        }
    }
}
