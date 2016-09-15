using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace SpiritMod.Items.Accessory
{
    public class VitalityStone : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Vitality Stone";  
            item.width = 48;     
            item.height = 49;   
            item.toolTip = "Increases life regen and invincibility time slightly";
			item.toolTip2 = "'The night is dark and full of terrors'";
            item.rare = 9;
            item.useSound = 11;
            item.accessory = true;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.value = Item.sellPrice(0, 0, 6, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 3;   
        }
    }
}
