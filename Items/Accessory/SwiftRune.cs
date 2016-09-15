using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

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
            item.rare = 1;
            item.useSound = 11;
            item.accessory = true;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.value = Item.sellPrice(0, 0, 6, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownVelocity += 0.20f;
            player.moveSpeed += 0.15f;
        }
    }
}
