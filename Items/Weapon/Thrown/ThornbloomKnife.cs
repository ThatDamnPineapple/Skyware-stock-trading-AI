using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class ThornbloomKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Thornbloom Knife";
            item.useStyle = 1;
            item.width = 30;
            item.toolTip = "Leaves damaging spores in its wake";
            item.height = 50;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ThornbloomKnifeProj");
            item.useAnimation = 21;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 21;
            item.shootSpeed = 14.5f;
            item.damage = 60;
            item.knockBack = 5.5f;
			item.value = Item.sellPrice(0, 0, 10, 0);
           	item.value = Item.buyPrice(0, 0, 30, 0);
            item.rare = 8;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }
    }
}
