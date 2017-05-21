using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class VenomBlade : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Venom Blade";
            item.damage = 52;
            item.useTime = 26;
            item.useAnimation = 26;
            item.melee = true;            
            item.width = 60;              
            item.height = 64;             
            item.toolTip = "Occasionally shoots out a bolt of powerful venom";
            item.useStyle = 1;        
            item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.shootSpeed = 10;
            item.UseSound = SoundID.Item1;   
            item.autoReuse = true;
            item.useTurn = true;
            item.crit = 12;
            item.shoot = mod.ProjectileType("GeodeStaveProjectile");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int I = 0; I < 1; I++)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 355, 40, knockBack, item.owner);
                }
            }
                return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}