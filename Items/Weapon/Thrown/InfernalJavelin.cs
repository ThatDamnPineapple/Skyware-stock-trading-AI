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
            item.toolTip = "A spear forged with fire";
            item.rare = 5;
            item.value = Terraria.Item.sellPrice(0, 3, 70, 0);
            item.damage = 46;
            item.knockBack = 6;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 28;
            item.thrown = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("InfernalJavelin");
            item.shootSpeed = 14;
            item.UseSound = SoundID.Item1;
        }
    }
}