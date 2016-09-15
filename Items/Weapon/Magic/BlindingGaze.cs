using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BlindingGaze : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Blinding Gaze";
            item.damage = 19;
            item.magic = true;
            item.mana = 13;
            item.width = 46;
            item.height = 46;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 3;
            item.useSound = 34;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("LightWave");
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
