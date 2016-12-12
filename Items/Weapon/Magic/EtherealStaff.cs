using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class EtherealStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ethereal Staff ";
			item.damage = 42;
			item.magic = true;
			item.mana = 10;
			item.width = 38;
			item.height = 38;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true; 
			item.noMelee = true;
            item.knockBack = 23;
            item.toolTip = "Inflicts Essence Trap";
			item.value = 1000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("EtherealStaffProjectile");
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.shootSpeed = 8f;
            item.crit = 6;
        }
	}
}