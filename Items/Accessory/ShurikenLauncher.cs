using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ShurikenLauncher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Throwers Glove";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "Gives your Shuriken an Boost!";
            item.toolTip2 = "Increased Thrown Crit and Damage";
            item.value = Item.sellPrice(0, 0, 66, 0);
            item.rare = 2;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.10f;
            player.thrownCrit += 4;            
        }
    }
}
