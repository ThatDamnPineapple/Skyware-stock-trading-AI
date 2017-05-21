using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	public class MagicBullet : ModItem
	{
        public override void SetDefaults()
        {
            item.name = "Magic Bullet";
            item.width = 8;
            item.height = 16;
            item.toolTip = "'Extremely unstable'";
            item.toolTip2 = "Homes in on enemies and phases through walls";
            item.value = Item.buyPrice(0, 0, 20, 0);
            item.rare = 10;

            item.maxStack = 999;

            item.damage = 25;
            item.knockBack = 1.5f;
            item.ammo = AmmoID.Bullet;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("MagicBullet");
            item.shootSpeed = 15f;

        }
	}
}