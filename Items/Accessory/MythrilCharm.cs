using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class MythrilCharm : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mythril Charm";
            item.toolTip = "Taking damage deals damage to enemies in an area around you";
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 9;
            item.accessory = true;
            item.defense = 6;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).mythrilCharm = true;
        }
    }
}
