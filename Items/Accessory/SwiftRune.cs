using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class SwiftRune : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Swiftness Rune";  
            item.width = 42;     
            item.height = 42;   
            item.toolTip = "Gives your Shuriken an Boost!";
            item.toolTip2 = "Increased Thrown Velocity and Movement Speed";
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = 1;
            
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownVelocity += 0.20f;
            player.moveSpeed += 0.15f;
        }
    }
}
