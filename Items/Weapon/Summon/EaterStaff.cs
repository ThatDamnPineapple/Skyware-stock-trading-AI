using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class EaterStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater Staff");
            Tooltip.SetDefault("Summons a tiny Eater of Souls to fight for you");

        }


		public override void SetDefaults()
		{
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 2;
            item.mana = 8;
            item.damage = 13;
            item.knockBack = 1;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;    
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("EaterSummon");
            item.buffType = mod.BuffType("EaterSummonBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}