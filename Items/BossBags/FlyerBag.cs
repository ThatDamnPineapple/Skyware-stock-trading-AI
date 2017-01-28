using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class FlyerBag : ModItem
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
			     player.QuickSpawnItem(mod.ItemType("FlierWings")); 
			string[] lootTable = { "TalonBlade", "Talonshot", "TalonPiercer", "TalonBurst", "Talonginus" };
			int loot = Main.rand.Next(lootTable.Length);
			 int Randd = Main.rand.Next(32, 44);
                for (int I = 0; I < Randd; I++)
                {
                   player.QuickSpawnItem(mod.ItemType("Talon"));
				}
			player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
