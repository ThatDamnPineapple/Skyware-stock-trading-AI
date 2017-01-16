using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class DusksEnd : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Dusk's End";
			item.damage = 42;
			item.magic = true;
			item.mana = 14;
			item.width = 52;
			item.height = 52;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			Item.staff[item.type] = true; 
			item.noMelee = true; 
			item.knockBack = 2;
			item.value = 18000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DuskShot");
			item.shootSpeed = 5f;
        }
	}
}