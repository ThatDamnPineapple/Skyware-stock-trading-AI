using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

using System.Collections.Generic;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod.Items
{
    public class GItem : GlobalItem
    {
		public bool FrostGlyph = false;
		public bool PoisonGlyph = false;
		public bool BloodGlyph = false;
		public bool FlareGlyph = false;
		public bool BeeGlyph = false;
		public bool PhaseGlyph = false;
		public bool DazeGlyph = false;
		public bool CamoGlyph = false;
		public bool VoidGlyph = false;
        public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		 public override void UpdateInventory(Item item, Player player)
        {
			if(FrostGlyph || PoisonGlyph || FlareGlyph || BeeGlyph|| DazeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
			{
				BloodGlyph = false;
			}
		    if(BloodGlyph || PoisonGlyph || FlareGlyph || BeeGlyph|| DazeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
			{
				FrostGlyph = false;
			}
			if (BloodGlyph || FrostGlyph || FlareGlyph || BeeGlyph|| DazeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
			{
				PoisonGlyph = false;
			}
			if (FrostGlyph || BloodGlyph || PoisonGlyph || BeeGlyph|| DazeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
			{
				FlareGlyph = false;
			}
		if (FlareGlyph || PoisonGlyph || FrostGlyph || BloodGlyph || DazeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
		{
			BeeGlyph = false;
		}
		if (FlareGlyph || PoisonGlyph || FrostGlyph || BloodGlyph || BeeGlyph || PhaseGlyph|| CamoGlyph|| VoidGlyph)
		{
			DazeGlyph = false;
		}
		if (DazeGlyph || PoisonGlyph || FrostGlyph || BloodGlyph || BeeGlyph || FlareGlyph || CamoGlyph || VoidGlyph)
		{
			PhaseGlyph = false;
		}
		if (DazeGlyph || PoisonGlyph || FrostGlyph || BloodGlyph || BeeGlyph || FlareGlyph || PhaseGlyph || VoidGlyph)
		{
			CamoGlyph = false;
		}
		if (DazeGlyph || PoisonGlyph || FrostGlyph || BloodGlyph || BeeGlyph || FlareGlyph || PhaseGlyph || CamoGlyph)
		{
					VoidGlyph = false;
		}
		
        if (FrostGlyph)
        {
	     	{
               item.crit = 6;
			}
        }
	    if (PoisonGlyph)
		{
			item.crit = 5;
		}
	    if(FlareGlyph)
		{
			item.shootSpeed = 20;
		}
        }
		 public override void HoldItem(Item item, Player player)
		 {
			 if(FrostGlyph)
			 {
              player.AddBuff(mod.BuffType("FrostGlyphBuff"), 2);
			 }
			 if (BloodGlyph)
			 {
		     player.AddBuff(mod.BuffType("BloodGlyphBuff"), 2);
			
			 }
			  if (PoisonGlyph)
			 {
		     player.AddBuff(mod.BuffType("PoisonGlyphBuff"), 2);
			
			 }
    		  if (FlareGlyph)
			 {
		     player.AddBuff(mod.BuffType("FlareGlyphBuff"), 2);
			 		     player.AddBuff(BuffID.OnFire, 2);
			
			 }
			  if (BeeGlyph)
			 {
		     player.AddBuff(mod.BuffType("BeeGlyphBuff"), 2);
			
			 }
			   if (DazeGlyph)
			 {
		     player.AddBuff(mod.BuffType("DazeGlyphBuff"), 2);
			
			 }
			   if (PhaseGlyph)
			 {
		     player.AddBuff(mod.BuffType("PhaseGlyphBuff"), 2);
			
			 }
		     if (CamoGlyph)
			 {
		     player.AddBuff(mod.BuffType("CamoGlyphBuff"), 2);
			
			 }
			 if (VoidGlyph)
			 {
		     player.AddBuff(mod.BuffType("VoidGlyphBuff"), 2);
			
			 }
		 }
		 public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        { 
			if(FrostGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Frostfreeze]\nIncreases critical strike chance by 6%\nEnemies near you are slowed");
            line.overrideColor = new Color(80, 80, 200);
            tooltips.Add(line);
			}
			if(BloodGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Sanguine Strike]\nAttacks inflict Blood Corruption\nHitting enemies with Blood Corruption may steal life");
            line.overrideColor = new Color(200, 80, 80);
            tooltips.Add(line);
			}
			if(PoisonGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Rotting Wounds]\nIncreases critical strike chance by 5%\nLanding critical strikes on foes may release poisonous clouds");
            line.overrideColor = new Color(80, 200, 80);
            tooltips.Add(line);
			}
			if(FlareGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Flare Frenzy]\nThe player is engulfed in flames\nGreatly increases the velocity of projectiles\nAttacks may inflict On Fire\nAttacks may also deal extra damage");
            line.overrideColor = new Color(255, 153, 10);
            tooltips.Add(line);
			}
			if(BeeGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Wasp Call]\nReduces movement speed by 7%\nAttacks may release multiple bees");
            line.overrideColor = new Color(158, 125, 10);
            tooltips.Add(line);
			}
			if(DazeGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Dazed Dance]\nAll attacks inflict confusion\nConfused enemies take extra damage\nGetting hurt may confuse the player");
            line.overrideColor = new Color(163, 22, 224);
            tooltips.Add(line);
			}
			if(PhaseGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Phase Flux]\n20% increased movement speed\nGrants immunity to knockback\nReduces defense by 5");
            line.overrideColor = new Color(255, 217, 30);
            tooltips.Add(line);
			}
			if(CamoGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Concealment]\nBeing still puts you in stealth\nStealth increases damage by 15% and life regen by 3");
            line.overrideColor = new Color(22, 188, 127);
            tooltips.Add(line);
			}
			if(VoidGlyph)
			{
            TooltipLine line = new TooltipLine(mod, "ItemName", "[Concealment]\nGrants you Collapsing Void, which reduces damage taken by 5%\nCrits on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\nHitting foes when having more than one stack of Collapsing Void may generate Void Stars");
            line.overrideColor = new Color(120, 31, 209);
            tooltips.Add(line);
			}
        }
		public override void PostReforge (Item item)
		{
			FrostGlyph = false;
			BloodGlyph = false;
			PoisonGlyph = false;
			DazeGlyph = false;
			BeeGlyph = false;
			FlareGlyph = false;
			PhaseGlyph = false;
			CamoGlyph = false;
			VoidGlyph = false;
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
            if (player.GetModPlayer<MyPlayer>(mod).titanicSet)
            {
				if (player.inventory[player.selectedItem].melee)
				{
					                    if (Main.rand.Next(6) == 0)
                {
     int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WaterMass"), 40, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                }
				}
            }
            if (player.GetModPlayer<MyPlayer>(mod).fierySet)
            {
                if (player.inventory[player.selectedItem].ranged || player.inventory[player.selectedItem].thrown)
                {
                    if (Main.rand.Next(8) == 0)
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
            if (player.GetModPlayer<MyPlayer>(mod).thermalSet)
            {
                if (player.inventory[player.selectedItem].melee)
                {
                    if (Main.rand.Next(6) == 0)
                    {
                        for (int I = 0; I < 4; I++)
                        {
                           int pl = Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(300, 500) / 100), speedY * (Main.rand.Next(300, 500) / 100), 134, 65, 7f, player.whoAmI, 0f, 0f);
                            Main.projectile[pl].friendly = true;
                            Main.projectile[pl].hostile = false;
                        }
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).timScroll)
            {
                if (player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(12) == 0)
                    {
                        int p = Main.rand.Next(9, 22);
                        {
                            int pl = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, p, damage, knockBack, player.whoAmI, 0f, 0f);
                            Main.projectile[pl].friendly = true;
                            Main.projectile[pl].hostile = false;
                        }
                    }
                }
            }
			 if (player.GetModPlayer<MyPlayer>(mod).crystal)
            {
                if (player.inventory[player.selectedItem].ranged)
                {
                    if (Main.rand.Next(8) == 0)
                    {
                        {
                            int pl = Projectile.NewProjectile(position.X, position.Y, speedX * (float)(Main.rand.Next(100,165) / 100), speedY * (float)(Main.rand.Next(100,165) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
                            Main.projectile[pl].friendly = true;
                            Main.projectile[pl].hostile = false;
                        }
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
          
            if (player.GetModPlayer<MyPlayer>(mod).fireMaw)
            {
                if (player.inventory[player.selectedItem].ranged)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("FireMaw"), 30, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;
                    }
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).drakinMount)
            {
                if (player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 671, 41, 3f, player.whoAmI);
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
			if (BeeGlyph)
            {
                {
                    if (Main.rand.Next(8) == 0 && !Main.hardMode)
                    {
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 181, 20, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;

                        int proj1 = Projectile.NewProjectile(position, new Vector2(speedX + 1, speedY), 181, 20, 2f, player.whoAmI);
                        Main.projectile[proj1].hostile = false;
                        Main.projectile[proj1].friendly = true;
                        int proj3 = Projectile.NewProjectile(position, new Vector2(speedX, speedY - 1), 181, 20, 2f, player.whoAmI);
                        Main.projectile[proj3].hostile = false;
                        Main.projectile[proj3].friendly = true;
                    }
					else 
					{
				    if (Main.rand.Next(8) == 0 && Main.hardMode)
                    {
                        int proj4 = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 181, 35, 2f, player.whoAmI);
                        Main.projectile[proj4].hostile = false;
                        Main.projectile[proj4].friendly = true;

                        int proj5 = Projectile.NewProjectile(position, new Vector2(speedX + 1, speedY), 181, 35, 2f, player.whoAmI);
                        Main.projectile[proj5].hostile = false;
                        Main.projectile[proj5].friendly = true;
                        int proj6 = Projectile.NewProjectile(position, new Vector2(speedX, speedY - 1), 181, 35, 2f, player.whoAmI);
                        Main.projectile[proj6].hostile = false;
                        Main.projectile[proj6].friendly = true;
                    }
					}
                }
            }
            if (player.GetModPlayer<MyPlayer>(mod).manaWings)
            {
                if (player.inventory[player.selectedItem].magic)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        float d1 = 20 + ((player.statManaMax2 - player.statMana) / 3);
                        int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("ManaSpark"), (int)d1, 2f, player.whoAmI);
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].friendly = true;

                    }
                }
            }
                return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
