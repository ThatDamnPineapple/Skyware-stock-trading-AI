using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class BlackPearl : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Black Pearl";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.rare = 3;
            item.maxStack = 99;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType <= 0 && InvasionWorld.invasionType <= 0;
        }

        public override bool UseItem(Player player)
        {
            InvasionHandler.StartCustomInvasion(SpiritMod.customEvent);
            return true;
        }
    }
}
