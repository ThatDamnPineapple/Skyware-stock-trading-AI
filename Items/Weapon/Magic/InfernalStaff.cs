using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Magic
{
    public class InfernalStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Staff";
            item.width = 42;
            item.height = 42;
            item.toolTip = "Launches fire spikes that split into flametrails!";
            item.rare = 2;
            item.mana = 10;
            item.damage = 45;
            item.knockBack = 0.2F;
            item.useStyle = 5;
            item.value = Terraria.Item.sellPrice(0, 6, 70, 0);
            item.useTime = 24;
            item.useAnimation = 24;
            Item.staff[item.type] = true;
            item.magic = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FireSpike_Friendly");
            item.shootSpeed = 12f;
        }
    }
}