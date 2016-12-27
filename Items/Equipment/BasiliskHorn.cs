using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            item.value = 10000;
            item.rare = 5;

            item.useStyle = 4;
            item.useTime = 20;
            item.useAnimation = 20;

			item.noMelee = true;

			item.mountType = mod.MountType("BasiliskMount");

            item.UseSound = SoundID.Item25;
        }
	}
}
