using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class ReachStaffChest : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Thornwild Staff";
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 2;
            item.mana = 7;
            item.damage = 7;
            AddTooltip("Summons a Briar Elemental to fight for you");
            item.knockBack = 2;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;    
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ReachSummon");
            item.buffType = mod.BuffType("ReachSummonBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}