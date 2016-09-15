using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class VineWand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Vine Wand";
            item.damage = 18;
            item.magic = true;
            item.mana = 15;
            item.width = 46;
            item.height = 46;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 20000;
            item.rare = 2;
            item.useSound = 20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("ThornVine");
            item.shootSpeed = 16f;
            item.toolTip = "Creates a thorny vine";
        }

        /*public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
           
        }*/

        public override void AddRecipes()
        {
            // To be determined
        }
    }
}
