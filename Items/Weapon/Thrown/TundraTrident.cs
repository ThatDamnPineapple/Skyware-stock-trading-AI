using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Thrown
{
    // IRIAZUL
    public class TundraTrident : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tundra Trident");
		}


        public override void SetDefaults()
        {
            item.width = 9;
            item.height = 15;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 9;
            item.maxStack = 999;
            item.crit = 10;
            item.damage = 85;
            item.knockBack = 5.5f;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.thrown = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("TundraTridentProjectile");
            item.shootSpeed = 11.5f;
            item.UseSound = SoundID.Item1;
        }
    }
}