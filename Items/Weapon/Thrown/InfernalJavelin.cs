using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class InfernalJavelin : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Javelin";
            item.width = item.height = 42;
            item.toolTip = "???";
            item.rare = 4;
            item.maxStack = 999;

            item.damage = 10;
            item.knockBack = 2;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 25;

            item.melee = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("InfernalJavelin");
            item.shootSpeed = 10;

            item.useSound = 1;
        }
    }
}
