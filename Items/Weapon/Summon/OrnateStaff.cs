using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class OrnateStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ornate Staff";
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 68, 46);
            item.rare = 1;
            item.mana = 10;
            item.damage = 5;
            item.toolTip = "Summons a beetle minion to fight for you!";
            item.knockBack = 7;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;           
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("BeetleMinion");
            item.buffType = mod.BuffType("BeetleMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}