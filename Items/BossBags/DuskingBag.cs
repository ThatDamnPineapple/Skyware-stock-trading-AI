using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class DuskingBag : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right Click to open");
		}


        public override void SetDefaults()
        {
			item.width = 20;
            item.height = 20;
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
            string[] lootTable = {"ShadowflameSword", "UmbraStaff", "ShadowSphere", "CrystalShadow", "DuskCarbine" };
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
            int yikea = Main.rand.Next(3, 7);
            {
                for (int I = 0; I < yikea; I++)
                {
                    player.QuickSpawnItem(ItemID.GoldCoin);
                }
            }
            player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
