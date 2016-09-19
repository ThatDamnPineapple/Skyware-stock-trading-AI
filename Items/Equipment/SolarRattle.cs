using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Equipment
{
	public class SolarRattle : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Solar Rattle";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Summons a Drakomire into battle";
			item.toolTip += "\nWhen riding the Drakomire, defense is increased by 40,";
			item.toolTip += "\na fiery trail is left behind and knockback is ignored.";
			item.toolTip += "\nThe Drakomire also builds up stamina, allowing for a dash every 10 seconds.";
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = -12;

			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;

			item.noMelee = true;

			item.mountType = mod.MountType("Drakomire");

			item.useSound = 79;
		}
	}
}
