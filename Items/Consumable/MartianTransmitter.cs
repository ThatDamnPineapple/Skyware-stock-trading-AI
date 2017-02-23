using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class MartianTransmitter : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Martian Transmitter";
            item.width = item.height = 16;
            item.toolTip = "Summons the martian invasion";
            item.toolTip2 = "'Broadcasting on strange frequencies'";
            item.rare = 9;
            item.maxStack = 99;
            item.value = 100000;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        

        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 64, 399);
            return true;
        }

       
    }
}
