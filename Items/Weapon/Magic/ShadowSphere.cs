using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class ShadowSphere : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Sphere");
			Tooltip.SetDefault("Summons slow moving shadow spheres");
		}


		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.rare = 5;
			item.damage = 54;
			item.useStyle = 5;
			item.UseSound = SoundID.Item20;
			Item.staff[item.type] = true;
			item.useTime = 36;
			item.useAnimation = 36;
			item.mana = 10;
			item.magic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("ShadowCircleRune");
			item.shootSpeed = 3f;
		}
	}
}
