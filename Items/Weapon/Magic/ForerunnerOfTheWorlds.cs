using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class ForerunnerOfTheWorlds : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Forerunner of the Worlds";
            item.damage = 72;
            item.magic = true;
            item.mana = 16;
            item.width = 28;
            item.height = 30;
            item.toolTip = "Shoots a fan of homing earth";
            item.useTime = 25;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 19000;
            item.rare = 2;
            item.useSound = 8;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("EarthenBolt");
            item.shootSpeed = 12f;
            item.autoReuse = true;
        }

        //Ned to comment this out until i can find a fix for it. It currently makes to omany projectiles, therefore making too many dusts, therefore the game tries to get rid of the projectiles
        /*public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 5.75f * 0.0174f;
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 3f;
            double offsetAngle;
            int i;
            for (i = 0; i < 5; i++)
            {
                offsetAngle = startAngle + deltaAngle * i;
                Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("EarthenBolt"), damage, knockBack, item.owner);
            }
            return false;
        }*/
    }
}