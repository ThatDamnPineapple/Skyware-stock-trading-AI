using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class Boquet : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blazing Boquet";
			item.damage = 59;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
            item.useTime = 40;
            item.useAnimation = 40;
            item.toolTip = "'The perfect Prom gift!'";
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 6;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 6;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("BoquetBlast");
			item.shootSpeed = 10f;
		}
		
		
	}
}
