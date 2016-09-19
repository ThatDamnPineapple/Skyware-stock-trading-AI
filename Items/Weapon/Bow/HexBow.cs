using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Bow
{
    public class HexBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Hex Bow";
            item.width = 69;
            item.height = 40;
            item.toolTip = "Transforms arrows in to Ichor Arrows";
            item.value = 1000;
            item.rare = 4;

            item.crit = 4;
            item.damage = 42;
            item.knockBack = 3;

            item.useStyle = 5;
            item.useTime = 16;
            item.useAnimation = 16;

            item.useAmmo = 1;

            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = true;

            item.shoot = 3;
            item.shootSpeed = 8;

            item.useSound = 5;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.IchorArrow, damage, knockBack, player.whoAmI, 0f, 0f);
            return true;
        }

        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(5, 4);
        }
    }
}