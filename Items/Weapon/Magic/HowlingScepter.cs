using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Magic
{
    public class HowlingScepter : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Frigid Scepter";
            item.damage = 13;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.magic = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 52;
            item.mana = 6;
            item.toolTip = "Shoots out a chilling bolt";
            item.useAnimation = 52;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 800;
            item.rare = 1;
            item.autoReuse = false;
            item.shootSpeed = 8;
            item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("HowlingBolt");
        }

        public override void AddRecipes()
        {

            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "FrigidFragment", 12);
            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
