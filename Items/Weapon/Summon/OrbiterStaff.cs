using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
    public class OrbiterStaff : ModItem
    {

        int charger;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orbiter Staff");
            Tooltip.SetDefault("Summons a mini meteor to charge at foes\nEvery third summon also calls a more powerful Unstable Meteor");
        }


        public override void SetDefaults()
        {
            item.width = 56;
            item.height = 62;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = 3;
            item.mana = 14;
            item.damage = 16;
            item.knockBack = 3;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("Minior");
            item.buffType = mod.BuffType("MiniorBuff");
            item.UseSound = SoundID.Item44;
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            charger++;
            if (charger >= 3)
            {
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BigMeteor"), 20, knockBack, player.whoAmI, 0f, 0f);
                }
                charger = 0;
            }
            return true;
        }
    }
}