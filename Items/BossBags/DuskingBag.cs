using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class DuskingBag : ModItem
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
            return true;
        }

        public override void RightClick(Player player)
		{
               player.QuickSpawnItem(mod.ItemType("DuskPendant")); 
            string[] lootTable = { "ShadowGauntlet", "ShadowflameSword", "UnbraStaff", "ShadowSphere", "CrystalShadow", };
			int loot = Main.rand.Next(lootTable.Length);
			 int Randd = Main.rand.Next(25, 36);
                for (int I = 0; I < Randd; I++)
                {
                   player.QuickSpawnItem(mod.ItemType("DuskStone"));
				}
				if (lootTable[loot] == "CrystalShadow")
				{
					int Randd2 = Main.rand.Next(29, 49);
					for (int D = 0; D < Randd2; D++)
					{
						player.QuickSpawnItem(mod.ItemType("CrystalShadow"));
					}
				}
			player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
