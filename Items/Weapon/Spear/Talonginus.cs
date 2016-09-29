using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear {
public class Talonginus : ModItem
{
	private Vector2 newVect;
    public override void SetDefaults()
    {
        item.name = "Talonginus"; 
		item.damage = 21;
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.useSound = 1;
		item.autoReuse = true;
        item.melee = true;
        item.noMelee = true;
        item.useAnimation = 7;
        item.useTime = 7;
        item.shootSpeed = 9f;
        item.knockBack = 6f;
        item.value = Item.sellPrice(0, 1, 30, 0);
        item.rare = 3;
		item.expert = true;
		item.crit = 6;
        item.shoot = mod.ProjectileType("TalonginusProj");
    }
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
			Vector2 origVect = new Vector2(speedX, speedY);
				if (Main.rand.Next(2) == 1)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
				}
				speedX = newVect.X;
				speedY = newVect.Y;
				if (Main.rand.Next(5) == 3)
				{
					return false;
				}
				else{
			return true;
				}
		}
    
}}
