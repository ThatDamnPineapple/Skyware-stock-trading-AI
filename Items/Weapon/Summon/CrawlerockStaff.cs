using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class CrawlerockStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crawlerock Staff";
            item.width = 26;
            item.toolTip = "Sumons bouncing mini crawlers to fight for you!";
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.mana = 11;
            item.damage = 10;
            item.knockBack = 3;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("Crawlerock");
            item.buffType = mod.BuffType("CrawlerockMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}