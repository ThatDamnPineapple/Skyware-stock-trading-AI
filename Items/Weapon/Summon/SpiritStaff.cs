using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
	public class SpiritStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Staff";
			item.width = 26;
			item.height = 28;
			item.toolTip = "Summons an unbound soul to shoot Essence-trapping spirit flames at foes!";
			item.value = Item.buyPrice(0, 6, 0, 0);
			item.rare = 10;
			item.damage = 100;
			item.useStyle = 1;
			item.useTime = 36;
			item.useAnimation = 36;
			item.mana = 10;
			item.summon = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("UnboundSoul");
			item.buffType = mod.BuffType("UnboundSoulMinionBuff");
			item.buffTime = 3600;
			item.UseSound = SoundID.Item44;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = (float)Main.mouseX + Main.screenPosition.X;
			position.Y = (float)Main.mouseY + Main.screenPosition.Y;
			Terraria.Projectile.NewProjectile(position.X, position.Y, 0f, 0f, type, 10, 0.5f, player.whoAmI, (float)Main.rand.Next(1, 4), 0f);
			return false;
		}
	}
}
