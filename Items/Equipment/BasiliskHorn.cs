using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Items.Equipment
{
	class BasiliskHorn : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Basilisk Horn";
			item.width = 22;
			item.height = 20;
			item.toolTip = "Summons a rideable Basilisk.";
			item.useStyle = 4;
			item.useSound = 25; //Maybe 79 ?
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 5;
			item.noMelee = true;
			item.mountType = mod.MountType("BasiliskMount");
			item.value = 10000;
		}
	}
}
