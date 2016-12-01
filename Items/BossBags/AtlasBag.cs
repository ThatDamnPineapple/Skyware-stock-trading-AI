using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class AtlasBag : ModItem
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
			     player.QuickSpawnItem(mod.ItemType("QuakeFist")); 
			string[] lootTable = { "KingRock", "Mountain", "TitanboundBulwark", "CragboundStaff", };

            int loot = Main.rand.Next(lootTable.Length);
			int Randd = Main.rand.Next(20, 46);
                for (int I = 0; I < Randd; I++)
                {
                   player.QuickSpawnItem(mod.ItemType("ArcaneGeyser"));
				}
			player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
