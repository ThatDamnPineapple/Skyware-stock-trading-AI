using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

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
            item.rare = 9;
            item.useSound = 11;
            item.accessory = true;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.value = Item.sellPrice(0, 0, 6, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;        
        }
    }
}
