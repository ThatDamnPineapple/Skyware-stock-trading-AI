using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace SpiritMod.Items.Weapon.Gun
{
    public class SoulStinger : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Soul Stinger";
            item.damage = 41;
            item.toolTip = "Shoots out an ethereal sting that phases through walls";
            item.ranged = true;
            item.width = 68;
            item.height = 24;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 6, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SoulSting");
            item.shootSpeed = 10f;
        }
		 public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("SoulSting");
            return true;
        }
    }
}