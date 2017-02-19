using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class SpiritFlameStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spiritflame Staff";
			item.damage = 49;
			item.magic = true;
			item.mana = 14;
			item.width = 40;
			item.height = 40;
			item.useTime = 32;
			item.useAnimation = 32;
            item.toolTip = "Shoots out a spirit bolt that explodes in 4 directions";
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 2000;
			item.rare = 6;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpiritBolt");
			item.shootSpeed = 5f;
		}
		
		
	}
}
