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
            item.name = "Rogue Emblem";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "Increases throwing damage by 15%";
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 3;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;        
        }
    }
}
