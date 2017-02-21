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
            item.toolTip = "Being hit spawns forth a damage reducing orb \n The orb reduces damage taken by 10% \n Increases life regeneration by 3";
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.defense = 2;
            item.rare = 3;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 3;
            player.GetModPlayer<MyPlayer>(mod).babyClamper = true;  
        }
    }
}
