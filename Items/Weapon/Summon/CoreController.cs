using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class CoreController : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core Controller");
			Tooltip.SetDefault("Summons a Molten Tank to fight for you!");
		}


		public override void SetDefaults()
		{
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 10, 0);
            item.rare = 6;
            item.crit = 4;
            item.mana = 7;
            item.damage = 35;
            item.knockBack = 0;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;            
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("TankMinion");
            item.buffType = mod.BuffType("TankMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            speedX = speedY = 0;
            return true;
        }
		
    }
}