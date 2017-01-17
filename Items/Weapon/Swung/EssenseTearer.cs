using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class EssenseTearer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Essense Tearer";
            item.width = 30;
            item.height = 10;
            item.toolTip = "Release power of aens";
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 11;
            item.crit = 8;
            item.damage = 165;
            item.knockBack = 8;
            item.useStyle = 5;
            item.useTime = item.useAnimation = 32;   
            item.scale = 1.1F;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("EssenseTearerProj");
            item.shootSpeed = 12.5F;
            item.UseSound = SoundID.Item1;   
        }
    }
}