using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyph
{
    public class Glyph : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glyph");
			Tooltip.SetDefault("Right Click to apply to held weapon");
		}


        public override void SetDefaults()
        {
			item.width = 20;
            item.height = 20;
            item.rare = -2;

            item.maxStack = 30;

			item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
		{
			Item item = player.inventory[player.selectedItem];
item.GetGlobalItem<GItem>(mod).Glyph = true;
        }
    }
}
