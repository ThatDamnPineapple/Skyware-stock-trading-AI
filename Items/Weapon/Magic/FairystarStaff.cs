using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class FairystarStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fairystar Staff"; 
            item.damage = 45;
            item.magic = true;
            item.mana = 7;
            item.width = 46;
            item.height = 46;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 20000;
            item.rare = 3;
            item.UseSound = SoundID.Item34;
			item.crit = 4;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Fae");
            item.shootSpeed = 7f;
            item.toolTip = "Creats a mighty gust of wind to damage your foes";
            item.autoReuse = true;
        }
    }
}
