using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
	public class ScarabBag : ModItem
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
			int Choice = Main.rand.Next(7);
			player.QuickSpawnItem(mod.ItemType("ScarabCharm"));
			/*for (int I = 0; I < Crystilium; I++)
			{
				player.QuickSpawnItem(mod.ItemType("CrystiliumBar"));
			}
			if (Choice == 0)
			{
			player.QuickSpawnItem(mod.ItemType("Cryst"));
			}
			if (Choice == 1)
			{
			player.QuickSpawnItem(mod.ItemType("Callandor"));
			}
			if (Choice == 2)
			{
			player.QuickSpawnItem(mod.ItemType("QuartzSpear"));
			}
			if (Choice == 3)
			{
			player.QuickSpawnItem(mod.ItemType("ShiningTrigger"));
			}
			if (Choice == 4)
			{
			player.QuickSpawnItem(mod.ItemType("Slamborite"));
			}
			if (Choice == 5)
			{
			player.QuickSpawnItem(mod.ItemType("Shimmer"));
			}
            if (Choice == 6)
            {
                player.QuickSpawnItem(mod.ItemType("Shatterocket"));
            }*/
        }
	}
}