using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class InfernonBag : ModItem
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
			   player.QuickSpawnItem(mod.ItemType("HellsGaze")); //is this the expert drop?
			string[] lootTable = { "InfernalJavelin", "DiabolicHorn", "SevenSins", "InfernalSword", "InfernalStaff", "InfernalShield", "EyeOfTheInferno",};
			int loot = Main.rand.Next(lootTable.Length);
			 int Randd = Main.rand.Next(25, 36);
                   player.QuickSpawnItem(mod.ItemType("InfernalAppendage"), Main.rand.Next(25, 36));
			player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
