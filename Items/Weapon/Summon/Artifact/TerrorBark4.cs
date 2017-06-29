using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
namespace SpiritMod.Items.Weapon.Summon.Artifact
{
	public class TerrorBark4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terror Bark");
			Tooltip.SetDefault("'You are the Artifact Keeper of Nightmares'\nTakes up two minion slots\nSummons a Terror Fiend to chatge at enemies\nTerror Fiends summon homing Wither Bolts\nWither bolts may inflict 'Wither' and steal life\nAddition summons recieve a significant buff to their damage and knockback, signified by a Nightmare Eye that appears above the player\nDirect hits on enemies with the Terror Fiend may cause enemies to erupt into Nightmare Explosions");
		}


		public override void SetDefaults()
		{
            item.width = 80;
            item.height = 82;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.mana = 12;
            item.damage = 65;
            item.knockBack = 2;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("Terror4Summon");
            item.buffType = mod.BuffType("Terror4SummonBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item60;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "ItemName", "Artifact Weapon");
            line.overrideColor = new Color(100, 0, 230);
            tooltips.Add(line);
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, mod.ProjectileType("NightmareEye2"), 0, 0, player.whoAmI, 0f, 0f);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TerrorBark3", 1);
            recipe.AddIngredient(null, "RadiantEmblem", 1);
            recipe.AddIngredient(null, "PlanteraBloom", 1);
            recipe.AddIngredient(null, "ApexFeather", 1);
            recipe.AddIngredient(null, "UnrefinedRuneStone", 1);
            recipe.AddIngredient(null, "Catalyst", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 150);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}