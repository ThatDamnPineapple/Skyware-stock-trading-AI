using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ReachBossSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodthorn Blade");
            Tooltip.SetDefault("Increases in damage and speed as health wanes\nOccasionally shoots out a bloody wave\nAlways shoots out waves when below 1/4 health\nMelee critical hits poison enemies and inflict 'Withering Leaf'");
        }


        public override void SetDefaults()
        {
            item.damage = 44;
            item.melee = true;
            item.width = 64;
            item.height = 62;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.shoot = mod.ProjectileType("BloodWave");
            item.rare = 5;
            item.shootSpeed = 8f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.statLife <= player.statLifeMax2 / 2)
            {
                item.damage = 50;
                item.useTime = 25;
                item.useAnimation = 25;
            }
            else if (player.statLife <= player.statLifeMax2 / 3)
            {
                item.damage = 52;
                item.useTime = 22;
                item.useAnimation = 22;
            }
            else if (player.statLife <= player.statLifeMax2 / 4)
            {
                item.damage = 55;
                item.useTime = 19;
                item.useAnimation = 19;
            }
            else
            {
                item.damage = 44;
                item.useTime = 29;
                item.useAnimation = 29;
            }
                return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next (2) == 1 && player.statLife >= player.statLifeMax2 / 4)
            {
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (crit)
            {
                target.AddBuff(BuffID.Poisoned, 240);
                target.AddBuff(mod.BuffType("WitheringLeaf"), 120, true);
            }
        }
    }
}