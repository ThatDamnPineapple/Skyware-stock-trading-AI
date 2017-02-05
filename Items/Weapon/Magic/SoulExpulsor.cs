using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class SoulExpulsor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Soul Expulsor";
			item.damage = 104;
			item.magic = true;
			item.mana = 16;
			item.width = 40;
			item.height = 40;
            item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 220000;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpiritShardFriendly");
			item.shootSpeed = 15f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int I = 0; I < 7; I++)
			{
			Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float) Main.rand.Next(-250, 250) / 100), speedY + ((float) Main.rand.Next(-250, 250) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
		
	}
}
