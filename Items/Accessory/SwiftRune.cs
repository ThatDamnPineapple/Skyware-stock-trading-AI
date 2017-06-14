using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class SwiftRune : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swiftness Rune");
			Tooltip.SetDefault("Gives your Shuriken a Boost!");
		}


        public override void SetDefaults()
        {
            item.width = 42;     
            item.height = 42;   
            item.toolTip2 = "Increases thrown velocity and movement speed";
            item.value = Item.sellPrice(0, 0, 66, 0);
            item.rare = 2;
            
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownVelocity += 0.20f;
            player.moveSpeed += 0.15f;
        }
    }
}
