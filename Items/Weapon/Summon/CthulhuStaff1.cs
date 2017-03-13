using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class CthulhuStaff1 : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "R'lyehian Scepter";
            item.width = 44;
            item.height = 44;
            item.value = Item.sellPrice(0, 7, 0, 0);
            item.rare = 5;
            item.mana = 12;
            item.damage = 32;
            item.knockBack = 3;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;          
            item.summon = true;
            item.toolTip = "Summons a mini R'lyehian to fight for you!";
            item.noMelee = true;
            item.shoot = mod.ProjectileType("Cthulhu");
            item.buffType = mod.BuffType("CthulhuBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}