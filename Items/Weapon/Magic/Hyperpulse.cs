using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class Hyperpulse : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Hyperpulse";
			item.damage = 16;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Shoots runes in all directions.";
			item.useTime = 17;
			item.useAnimation = 30;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 2100;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PulseRune");
			item.shootSpeed = 14f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float spread = 45f * 0.0174f;
    double startAngle = Math.Atan2(speedX, speedY)- spread/2;
    double deltaAngle = spread/8f;
    double offsetAngle;
    int i;
    for (i = 0; i < 4; i++ )
    {
        offsetAngle = (startAngle + deltaAngle * (i + i*i) / 2f) + 32f * i;
        Terraria.Projectile.NewProjectile(position.X, position.Y, (float)(Math.Sin(offsetAngle)*5f), (float)(Math.Cos(offsetAngle)*5f), item.shoot, damage, knockBack, item.owner);
        Terraria.Projectile.NewProjectile(position.X, position.Y, (float)(-Math.Sin(offsetAngle)*5f), (float)(-Math.Cos(offsetAngle)*5f), item.shoot, damage, knockBack, item.owner);
    }
    return false;
}
	}
}