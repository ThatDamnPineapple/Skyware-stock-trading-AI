using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class EmberSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ember Blade";
            item.damage = 50;
            item.useTime = 29;
            item.useAnimation = 29;
            item.melee = true;            
            item.width = 38;              
            item.height = 38;             
            item.toolTip = "Shoots out a wave of fire that slowly loses velocity ";
            item.useStyle = 1;        
            item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.shootSpeed = 12;
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
                {
                    Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EmberSwordProj"), 40, knockBack, item.owner);
                }
            }
                return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(null, "CarvedRock", 12);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}