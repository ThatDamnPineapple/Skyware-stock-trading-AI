using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class IceStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ice Staff";
            item.damage = 18;
            item.magic = true;
            item.mana = 15;
            item.width = 46;
            item.height = 46;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 2000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Icicle");
            item.shootSpeed = 16f;
            item.toolTip = "Fires 3 sharp icicles in a cone";
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 5.75f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 3f;
            double offsetAngle;
            int i;
            for (i = 0; i < 3; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("Icicle"), damage, knockBack, item.owner);
            }
            return false;
        }

        public override void AddRecipes()
        {
            //uhhhhhhh whatdoidohelpme
        }
    }
}
