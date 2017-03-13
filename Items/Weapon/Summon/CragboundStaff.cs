using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
	public class CragboundStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cragbound Staff";
            item.toolTip = "A tiny Earthen Guardian rains down energy for you \n Occasionally inflicts foes with 'Unstable Affliction'\n Uses 2 Minion slots";
            item.height = item.width = 54;
            item.value = Item.sellPrice(0, 8, 45, 0);
            item.rare = 9;
            item.mana = 20;
            item.damage = 112;
            item.knockBack = 7;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30; 
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CragboundMinion");
            item.buffType = mod.BuffType("CragboundMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int spawnX = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
            int spawnY = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
            if (player.gravDir == -1f)
            {
                spawnY = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
            }
            while (spawnY < Main.maxTilesY - 10 && Main.tile[spawnX, spawnY] != null && !WorldGen.SolidTile2(spawnX, spawnY) && Main.tile[spawnX - 1, spawnY] != null && !WorldGen.SolidTile2(spawnX - 1, spawnY) && Main.tile[spawnX + 1, spawnY] != null && !WorldGen.SolidTile2(spawnX + 1, spawnY))
            {
                spawnY++;
            }
            spawnY--;
            Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(spawnY * 16 - 24), 0f, 15f, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}