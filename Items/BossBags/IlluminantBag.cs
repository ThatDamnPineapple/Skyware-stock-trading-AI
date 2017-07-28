using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class IlluminantBag : ModItem
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
			     player.QuickSpawnItem(mod.ItemType("CrystalShield")); 
			string[] lootTable = { "SylphBow", "FairystarStaff", "FaeSaber", };
			int loot = Main.rand.Next(lootTable.Length);
                  player.QuickSpawnItem(mod.ItemType("IlluminatedCrystal"), Main.rand.Next(32, 44));

            int yikea = Main.rand.Next(4, 10);
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
