using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class ShadowflameStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Shadowflame Staff"; //update this all later
            item.damage = 30;
            item.magic = true;
            item.mana = 11;
            item.width = 46;
            item.height = 46;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 3;
            item.useSound = 104;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("ChaosBall");
            item.shootSpeed = 20f;
            item.autoReuse = true;
            item.toolTip = "Shoots Chaos Balls";
            item.scale = 1.2f;
        }


        public override void AddRecipes()
        {
            //Update later
        }
    }
}
