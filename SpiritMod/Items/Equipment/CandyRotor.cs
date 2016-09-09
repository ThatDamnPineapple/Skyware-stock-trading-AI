using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Equipment
{
	class CandyRotor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Candy Rotor";
			item.width = 16;
			item.height = 22;
			item.toolTip = "Ride a Helicopter to Victory!";
			item.toolTip2 = " ...a rather tiny one.";
			item.useStyle = 4;
			item.useSound = 25; //Find a better sound
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 7;
			item.noMelee = true;
			item.mountType = mod.MountType("CandyCopter");
			item.value = 50000;
		}
		
	}
}
