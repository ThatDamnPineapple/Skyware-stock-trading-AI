using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod.Items
{
    public class GItem : GlobalItem
    {
        public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<MyPlayer>(mod).talonSet)
            {
                if (player.inventory[player.selectedItem].ranged || player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY + 2), ProjectileID.HarpyFeather, 10, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).fierySet)
            {
                if (player.inventory[player.selectedItem].ranged || player.inventory[player.selectedItem].thrown)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.Fireball, 16, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).cultistScarf)
            {
                if (player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(8) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WildMagic"), 66, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).KingSlayerFlask)
            {
                if (player.inventory[player.selectedItem].thrown)
                {
                    if (Main.rand.Next(5) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX , speedY), mod.ProjectileType("KingSlayerKnife"), 35, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).MoonSongBlossom)
            {
                if (player.inventory[player.selectedItem].ranged)
                {
                    if (Main.rand.Next(8) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;

                        int proj1 = Projectile.NewProjectile(position, new Vector2(speedX +1, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
                        Main.projectile[proj1].hostile = false;
                        Main.projectile[proj1].friendly = true;

                        int proj2 = Projectile.NewProjectile(position, new Vector2(speedX, speedY -1), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
                        Main.projectile[proj2].hostile = false;
                        Main.projectile[proj2].friendly = true;
                    }
                }
            }
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
