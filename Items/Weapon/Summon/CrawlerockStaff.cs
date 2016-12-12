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
            item.height = 28;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;

            item.mana = 11;
            item.damage = 10;
            item.knockBack = 7;

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
