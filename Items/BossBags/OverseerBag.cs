using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class OverseerBag : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Treasure Bag";
			item.width = 20;
            item.height = 20;
            item.toolTip = "Right Click to open";
            item.rare = -2;

            item.maxStack = 30;

			item.expert = true;
        }

        public override bool CanRightClick()
        {
            return Main.expertMode;
        }

       public override void RightClick(Player player)
		{
			   //player.QuickSpawnItem(mod.ItemType("HellsGaze"));
			string[] lootTable = { "Eternity", "SoulExpulsor", "EssenseTearer", "AeonRipper", };
			int loot = Main.rand.Next(lootTable.Length);;
			player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
