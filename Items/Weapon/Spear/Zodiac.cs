using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear {
public class Zodiac : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Zodiac";
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.useSound = 1;
        item.melee = true;
        item.noMelee = true;
        item.useAnimation = 20;
        item.useTime = 20;
        item.shootSpeed = 5f;
        item.knockBack = 4f;
        item.damage = 125;
        item.value = Item.sellPrice(0, 1, 30, 0);
        item.rare = 3;
        item.shoot = mod.ProjectileType("ZodiacProj");
    }
}}