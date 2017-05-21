using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.DonatorItems
{
	public class SnakeStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Lihzahrd Wand";
            item.width = 26;
            AddTooltip("~ Donator Item ~");
            AddTooltip("Summons a friendly Flying Snake to shoot venom at foes");
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.mana = 13;
            item.damage = 44;
            item.knockBack = 1;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("SnakeMinion");
            item.buffType = mod.BuffType("SnakeMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}