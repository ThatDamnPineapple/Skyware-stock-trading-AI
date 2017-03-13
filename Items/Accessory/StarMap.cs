using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class StarMap : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Astral Map";  
            item.width = 34;     
            item.height = 56;   
            item.toolTip = "Increases movement speed by 12% and critical strike chance by 7% \n Getting hurt spawns stars from the sky";
			item.toolTip2 = "'Let the stars guide you'";
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 2;
            item.defense = 2;
            item.expert = true;
            item.accessory = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>(mod).starMap = true;
            player.moveSpeed += .12f;
            player.meleeCrit += 7;
            player.magicCrit += 7;
            player.thrownCrit += 7;
            player.rangedCrit += 7;
        }

    }
}
