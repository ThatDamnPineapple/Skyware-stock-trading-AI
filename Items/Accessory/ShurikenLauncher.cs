using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

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
            item.rare = 1;
            item.useSound = 11;
            item.accessory = true;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.value = Item.sellPrice(0, 0, 6, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.10f;
            player.thrownCrit = 4;            
        }
    }
}
