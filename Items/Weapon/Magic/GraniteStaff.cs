using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class GraniteStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Granite Staff"; 
            item.damage = 18;
            item.magic = true;
            item.mana = 12;
            item.width = 44;
            item.height = 44;
            item.useTime = 24;
            item.useAnimation = 18;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 50000;
            item.rare = 3;
            item.useSound = 9;
            item.shoot = mod.ProjectileType("GraniteSpike");
            item.shootSpeed = 8f;
            item.toolTip = "Shoots a cluster of Granite Spikes!";
            item.autoReuse = false;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 60 * 0.0174f; //change 60 to degrees you want
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / 5; //change 5 to what you wan the number to be
            double offsetAngle;
            int i;
            for (i = 0; i < 5; i++)//change 5 to what you wan the number to be
            {
                offsetAngle = startAngle + deltaAngle * i;
                Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 22);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
