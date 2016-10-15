using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class UnstableOrb : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.name = "Unstable Orb";        
            item.shoot = mod.ProjectileType("UnstableOrbProj");
            item.useAnimation = 30;
            item.useTime = 30;
            item.damage = 44;
        }

    }
}