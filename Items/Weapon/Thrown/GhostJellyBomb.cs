using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class GhostJellyBomb : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Ghost Jelly Bomb";
            item.width = 37;
            item.toolTip = "Throw an explosive, sticky jellyfish at foes!";
            item.height = 26;           
            item.shoot = mod.ProjectileType("GhostJellyBombProj");
            item.useAnimation = 27;
            item.useTime = 27;
            item.shootSpeed = 11f;
            item.damage = 35;
            item.knockBack = 1.0f;
			item.value = Terraria.Item.sellPrice(0, 0, 3, 0);
            item.crit = 6;
            item.rare = 5;
            item.thrown = true;
            item.autoReuse = false;
        }

       
    }
}
