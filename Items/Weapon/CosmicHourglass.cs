using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class CosmicHourglass : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cosmic Hourglass";
            item.damage = 0;
            AddTooltip("'You control the fabric of reality'");
            AddTooltip("Summons a Temporal Field at the cursor position");
            AddTooltip("The Temporal Field slows down any enemy in its midst");
            AddTooltip("Consumes 1/20 of the player's life on use");
            item.magic = true;
            item.mana = 80;
            item.width = 40;
            item.height = 40;
            item.useTime = 100;
            item.useAnimation = 100;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 10;
            item.shootSpeed = 4;
            item.shoot = mod.ProjectileType("Slow");
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Terraria.Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
            return false;
        }
        public override bool UseItem(Player player)
        {
            player.statLife -= player.statLifeMax2 / 20;
            return true;
        }
    }
}
