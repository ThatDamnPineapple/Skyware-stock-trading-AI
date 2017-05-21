using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class GremlinTooth : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Gremlin Tooth";  
            item.width = 20;     
            item.height = 22;
            AddTooltip("Getting hurt can grant you the 'Poison Bite' buff, causing all attacks to poison foes");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 5;
            item.accessory = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>(mod).gremlinTooth = true;
        }

    }
}
