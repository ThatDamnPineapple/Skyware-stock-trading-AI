using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class DuskingTreasureBag : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dusking Treasure Bag";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.rare = 10;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return Main.expertMode;
        }

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("DuskCarbine"));
            player.QuickSpawnItem(mod.ItemType("ShadowGauntlet"));
            player.QuickSpawnItem(mod.ItemType("ShadowflameSword"));
            player.QuickSpawnItem(mod.ItemType("UmbraStaff"));
            player.QuickSpawnItem(mod.ItemType("ShadowSphere"));
            player.QuickSpawnItem(mod.ItemType("DuskHood"));
            player.QuickSpawnItem(mod.ItemType("DuskPlate"));
            player.QuickSpawnItem(mod.ItemType("DuskLeggings"));
        }
    }
}
