using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Equipment
{
	public class DiabolicHorn : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Diabolic Horn";
			item.width = 22;
			item.height = 20;
			item.toolTip = "Provides a fiery platform to fly on";
            item.value = 10000;
            item.rare = 5;

            item.useStyle = 4;
            item.useTime = 20;
            item.useAnimation = 20;

			item.noMelee = true;

			item.mountType = mod.MountType("DiabolicPlatform");

            item.UseSound = SoundID.Item25;
        }
	}
}
