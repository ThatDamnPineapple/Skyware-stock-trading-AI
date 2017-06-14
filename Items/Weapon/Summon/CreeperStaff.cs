using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class CreeperStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creeper Wand");
            Tooltip.SetDefault("Summons a tiny Eater of Souls to fight for you");

        }


		public override void SetDefaults()
		{
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 2;
            item.mana = 12;
            item.damage = 15;
            item.knockBack = 0.5f;
            item.useStyle = 1;
            item.useTime = 27;
            item.useAnimation = 27;    
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CreeperSummon");
            item.buffType = mod.BuffType("CreeperSummonBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}