using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class QuakeFist : ModItem
	{
        private Vector2 newVect;
        public override void SetDefaults()
		{
			item.name = "Quake Fist";
			item.damage = 65;
			item.magic = true;
			item.mana = 12;
			item.width = 30;
			item.height = 34;
			item.toolTip = "Launches Prismatic fire \n Occasionally inflicts foes with 'Unstable Affliction'";
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;//this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 7, 0, 0);
            item.rare = 9;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PrismaticBolt");
			item.shootSpeed = 16f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PrismBolt2"), damage, knockBack, player.whoAmI);
            Projectile newProj = Main.projectile[proj];
            newProj.friendly = true;
            newProj.hostile = false;
            Vector2 origVect = new Vector2(speedX, speedY);
            for (int X = 0; X <= 2; X++)
            {
                if (Main.rand.Next(2) == 1)
                {
                    newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                else
                {
                    newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
                Projectile newProj2 = Main.projectile[proj2];
            }
            return false;
        }
    }
}