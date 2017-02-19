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
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<MyPlayer>(mod).talonSet)
            {
                if (player.inventory[player.selectedItem].ranged || player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.HarpyFeather, 10, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
