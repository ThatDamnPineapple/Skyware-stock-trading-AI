using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class ReachBossBag : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right-Click to open");
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
			     player.QuickSpawnItem(mod.ItemType("DeathRose")); 
			string[] lootTable = { "ThornBow", "SunbeamStaff", "ReachVineStaff", "ReachBossSword", "ReachKnife"};

            int loot = Main.rand.Next(lootTable.Length);
			int Randd = Main.rand.Next(14, 20);
                for (int I = 0; I < Randd; I++)
                {
                   player.QuickSpawnItem(mod.ItemType("ReachFlowers"));
				}
            int yikea = Main.rand.Next(1, 3);
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
