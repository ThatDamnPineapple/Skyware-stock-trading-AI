using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class DuskCarbine : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dusk Carbine";
            item.width = 54;
            item.height = 28;
            item.rare = 10;
            item.expert = true;
            item.UseSound = SoundID.Item36;
            item.crit = 4;
            item.damage = 34;
            item.knockBack = 6;

            item.useStyle = 5;
            item.useTime = 10;
            item.useAnimation = 20;
            item.reuseDelay = 16;

            item.ranged = true;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;

            item.shoot = 10;
            item.shootSpeed = 8;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
                type = mod.ProjectileType("ShadowflameBullet");

            return true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= item.useAnimation - 2;
        }
    }
}
