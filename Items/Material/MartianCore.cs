using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class MartianCore : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Martian Power Core");
			Tooltip.SetDefault("Crackling to the brim with Otherworldy Energy.");
		}


        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.rare = 9;

            item.maxStack = 999;
        }
    }
}
