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
            item.name = "Thrower's Glove";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "Gives your thrower weapons a Boost!";
            item.toolTip2 = "Increased thrown critical strike chance by 4% and throwing damage by 6%";
            item.value = Item.sellPrice(0, 0, 66, 0);
            item.rare = 2;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.06f;
            player.thrownCrit += 4;            
        }
    }
}
