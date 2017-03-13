using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class BabyClamper : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Baby Clamper";  
            item.width = 24;     
            item.height = 26;   
            item.toolTip = "Increases maximum number of minions by 1\n Increases life regeneration by 3";
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.defense = 2;
            item.rare = 3;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;
            player.maxMinions += 1;
        }
    }
}
