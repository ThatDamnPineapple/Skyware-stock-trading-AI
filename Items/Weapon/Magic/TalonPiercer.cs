using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class TalonPiercer : ModItem
    {
		private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Talon Piercer";
            item.damage = 18;
            item.magic = true;
            item.mana = 15;
            item.width = 46;
            item.height = 46;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 3.5f;
            item.value = 1000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = 38;
            item.shootSpeed = 8f;
            item.toolTip = "Shoots a barrage of feathers";
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
           Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X < 4; X++)
			{
				if (Main.rand.Next(2) == 1)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(92, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(92, 1800) / 10));
				}
			Projectile proj = Main.projectile[Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI)];
proj.friendly = true;
proj.hostile = false;
proj.netUpdate = true;
			}
			return false;
        }

    }
}
