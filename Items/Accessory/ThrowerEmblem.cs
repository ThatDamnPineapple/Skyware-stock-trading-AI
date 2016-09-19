using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ThrowerEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rogue emblem";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "+15% throwing damage";
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = 9;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;        
        }
    }
}
