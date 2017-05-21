using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ShadowSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Possessed Blade";
            item.damage = 51;
            item.melee = true;
            item.toolTip = "Occasionally leaves behind a shadow to damage foes";
            item.width = 44;
            item.height = 44;
            item.useTime = 35;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 1000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.value = Item.buyPrice(0, 4, 0, 0);
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useTurn = true;
            item.crit = 8;
            item.shoot = mod.ProjectileType("Shadow");
            item.shootSpeed = 0;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 109);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("Shadow"), damage, knockBack, item.owner);
            }
            return false;
        }
    }
}