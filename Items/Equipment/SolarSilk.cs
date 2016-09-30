using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Equipment
{
	public class SolarSilk : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Solar Silk";
			item.width = 22;
			item.height = 20;
			item.toolTip = "Summons a rideable baby Mothron.";
            item.value = 10000;
            item.rare = 5;

            item.useStyle = 4;
            item.useTime = 20;
            item.useAnimation = 20;

			item.noMelee = true;

			item.mountType = mod.MountType("BabyMothron");

            item.useSound = 25;
        }
	}
}
