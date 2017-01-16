using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class GastropodStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gastropod Staff";
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;
            item.mana = 10;
            item.damage = 38;
            item.knockBack = 7;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;        
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("GastropodMinion");
            item.buffType = mod.BuffType("GastropodMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}