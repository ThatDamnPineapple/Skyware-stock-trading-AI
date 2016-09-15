using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class ShadowflameBook : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tome of Shadowflames";
            item.damage = 46; // Change stats later - Voxel
            item.magic = true;
            item.mana = 10;
            item.width = 46;
            item.height = 46;
            item.useTime = 10;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 3;
            item.useSound = 34;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("ChaosBall");
            item.shootSpeed = 26f;
            item.toolTip = "...";
            item.autoReuse = false;
        }


        public override void AddRecipes()
        {
            //??
        }
    }
}
