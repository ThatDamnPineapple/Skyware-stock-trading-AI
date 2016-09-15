using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class InfernalStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Staff";
            item.width = 42;
            item.height = 42;
            item.toolTip = "???";
            item.rare = 5;

            item.mana = 1;
            item.damage = 10;
            item.knockBack = 0.2F;

            item.useStyle = 5;
            item.useTime = 8;
            item.useAnimation = 8;
            Item.staff[item.type] = true;

            item.magic = true;
            item.autoReuse = true;

            item.shoot = mod.ProjectileType("FireSpike_Friendly");
            item.shootSpeed = 12f;
        }
    }
}
