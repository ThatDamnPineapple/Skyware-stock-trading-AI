using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class LightsEnd : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Light's End";
            item.damage = 45;
            item.useTime = 26;
            item.useAnimation = 26;
            item.melee = true;            
            item.width = 60;              
            item.height = 64;             
            item.toolTip = "Launch a barrage of bloodlusted blades";
            item.useStyle = 1;        
            item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.shootSpeed = 1;
            item.UseSound = SoundID.Item1;   
            item.autoReuse = true;
            item.useTurn = true;
            item.crit = 6;
            item.shoot = mod.ProjectileType("GeodeStaveProjectile");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int I = 0; I < 3; I++)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("NightmareDagger"), damage, knockBack, item.owner);
            }
                return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NightmareFuel", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Wither"), 220);
        }
    }
}