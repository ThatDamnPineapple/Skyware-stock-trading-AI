using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class DuskStone : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dusk Stone");
			Tooltip.SetDefault("'The stone sparkles with twilight energies'\n Involved in the crafting of Dusk Armor");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.maxStack = 999;
            item.rare = 5;
        }
    }
}
