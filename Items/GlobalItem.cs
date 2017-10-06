using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

using System.Collections.Generic;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod.Items
{
	public class GItem : GlobalItem
	{
		public override bool InstancePerEntity
		{
			get { return true; }
		}

		public override bool CloneNewInstances
		{
			get { return true; }
		}

		private int glyph = 0;
		bool CandyToolTip = false;
		public bool FrostGlyph
		{
			get { return glyph == 1; }
			set 
			{
				if (value) { glyph = 1; }
				else if (glyph == 1) { glyph = 0; }
			}
		}
		public bool PoisonGlyph
		{
			get { return glyph == 2; }
			set 
			{
				if (value) { glyph = 2; }
				else if (glyph == 2) { glyph = 0; }
			}
		}
		public bool BloodGlyph
		{
			get { return glyph == 3; }
			set 
			{
				if (value) { glyph = 3; }
				else if (glyph == 3) { glyph = 0; }
			}
		}
		public bool FlareGlyph
		{
			get { return glyph == 4; }
			set
			{
				if (value) { glyph = 4; }
				else if (glyph == 4) { glyph = 0; }
			}
		}
		public bool BeeGlyph
		{
			get { return glyph == 5; }
			set
			{
				if (value) { glyph = 5; }
				else if (glyph == 5) { glyph = 0; }
			}
		}
		public bool PhaseGlyph
		{
			get { return glyph == 6; }
			set 
			{
				if (value) { glyph = 6; }
				else if (glyph == 6) { glyph = 0; }
			}
		}
		public bool DazeGlyph
		{
			get { return glyph == 7; }
			set 
			{
				if (value) { glyph = 7; }
				else if (glyph == 7) { glyph = 0; }
			}
		}
		public bool CamoGlyph
		{
			get { return glyph == 8; }
			set
			{
				if (value) { glyph = 8; }
				else if (glyph == 8) { glyph = 0; }
			}
		}
		public bool VoidGlyph
		{
			get { return glyph == 9; }
			set
			{
				if (value) { glyph = 9; }
				else if (glyph == 9) { glyph = 0; }
			}
		}

		public override bool NeedsSaving(Item item)
		{
			return glyph != 0;
		}

		public override TagCompound Save(Item item)
		{
			TagCompound data = new TagCompound();
			data.Add("glyph", glyph);
			return data;
		}

		public override void Load(Item item, TagCompound data)
		{
			glyph = data.GetInt("glyph");
		}

		public override void NetSend(Item item, BinaryWriter writer)
		{
			writer.Write(glyph);
		}

		public override void NetReceive(Item item, BinaryReader reader)
		{
			glyph = reader.ReadInt32();
		}

		public override void UpdateInventory(Item item, Player player)
		{
			if (FlareGlyph)
			{
				item.shootSpeed = 25;
			}
		}

        public override void GetWeaponCrit(Item item, Player player, ref int crit)
        {
            if (FrostGlyph)
            {
                crit += 6;
            }
            else if (PoisonGlyph)
            {
                crit += 5;
            }
        }

        public override void HoldItem(Item item, Player player)
		{
			if (FrostGlyph)
			{
				player.AddBuff(mod.BuffType("FrostGlyphBuff"), 2);
			}
			else if (BloodGlyph)
			{
				player.AddBuff(mod.BuffType("BloodGlyphBuff"), 2);

			} 
			else if (PoisonGlyph)
			{
				player.AddBuff(mod.BuffType("PoisonGlyphBuff"), 2);

			} 
			else if (FlareGlyph)
			{
				player.AddBuff(mod.BuffType("FlareGlyphBuff"), 2);
				player.AddBuff(BuffID.OnFire, 2);

			} 
			else if (BeeGlyph)
			{
				player.AddBuff(mod.BuffType("BeeGlyphBuff"), 2);

			} 
			else if (DazeGlyph)
			{
				player.AddBuff(mod.BuffType("DazeGlyphBuff"), 2);

			} 
			else if (PhaseGlyph)
			{
				player.AddBuff(mod.BuffType("PhaseGlyphBuff"), 2);

			} 
			else if (CamoGlyph)
			{
				player.AddBuff(mod.BuffType("CamoGlyphBuff"), 2);

			} 
			else if (VoidGlyph)
			{
				player.AddBuff(mod.BuffType("VoidGlyphBuff"), 2);

			}
		}

		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context != "goodieBag")
				return;
			_ItemUtils.DropCandy(player);
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (FrostGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Frostfreeze]\nIncreases critical strike chance by 6%\nEnemies near you are slowed");
				line.overrideColor = new Color(80, 80, 200);
				tooltips.Add(line);
			}
			else if (BloodGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Sanguine Strike]\nAttacks inflict Blood Corruption\nHitting enemies with Blood Corruption may steal life");
				line.overrideColor = new Color(200, 80, 80);
				tooltips.Add(line);
			}
			else if (PoisonGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Rotting Wounds]\nIncreases critical strike chance by 5%\nLanding critical strikes on foes may release poisonous clouds");
				line.overrideColor = new Color(80, 200, 80);
				tooltips.Add(line);
			}
			else if (FlareGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Flare Frenzy]\nThe player is engulfed in flames\nGreatly increases the velocity of projectiles\nAttacks may inflict On Fire\nAttacks may also deal extra damage");
				line.overrideColor = new Color(255, 153, 10);
				tooltips.Add(line);
			}
			else if (BeeGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Wasp Call]\nReduces movement speed by 7%\nAttacks may release multiple bees");
				line.overrideColor = new Color(158, 125, 10);
				tooltips.Add(line);
			}
			else if (DazeGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Dazed Dance]\nAll attacks inflict confusion\nConfused enemies take extra damage\nGetting hurt may confuse the player");
				line.overrideColor = new Color(163, 22, 224);
				tooltips.Add(line);
			}
			else if (PhaseGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Phase Flux]\n20% increased movement speed\nGrants immunity to knockback\nReduces defense by 5");
				line.overrideColor = new Color(255, 217, 30);
				tooltips.Add(line);
			}
			else if (CamoGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Concealment]\nBeing still puts you in stealth\nStealth increases damage by 15% and life regen by 3");
				line.overrideColor = new Color(22, 188, 127);
				tooltips.Add(line);
			}
			else if (VoidGlyph)
			{
				TooltipLine line = new TooltipLine(mod, "ItemName", "[Concealment]\nGrants you Collapsing Void, which reduces damage taken by 5%\nCrits on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\nHitting foes when having more than one stack of Collapsing Void may generate Void Stars");
				line.overrideColor = new Color(120, 31, 209);
				tooltips.Add(line);
			}
		}

		public override void PostReforge(Item item)
		{
			glyph = 0;
		}

		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.talonSet)
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
			if (modPlayer.titanicSet)
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
			if (modPlayer.fierySet)
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
			if (modPlayer.cultistScarf)
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
			if (modPlayer.thermalSet)
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
			if (modPlayer.timScroll)
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
			if (modPlayer.crystal)
			{
				if (player.inventory[player.selectedItem].ranged)
				{
					if (Main.rand.Next(8) == 0)
					{
						{
							int pl = Projectile.NewProjectile(position.X, position.Y, speedX * (float)(Main.rand.Next(100, 165) / 100), speedY * (float)(Main.rand.Next(100, 165) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
							Main.projectile[pl].friendly = true;
							Main.projectile[pl].hostile = false;
						}
					}
				}
			}

			if (modPlayer.KingSlayerFlask)
			{
				if (player.inventory[player.selectedItem].thrown)
				{
					if (Main.rand.Next(5) == 0)
					{
						int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("KingSlayerKnife"), 35, 2f, player.whoAmI);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;
					}
				}
			}

			if (modPlayer.fireMaw)
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
			if (modPlayer.drakinMount)
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
			if (modPlayer.MoonSongBlossom)
			{
				if (player.inventory[player.selectedItem].ranged)
				{
					if (Main.rand.Next(8) == 0)
					{
						int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;

						int proj1 = Projectile.NewProjectile(position, new Vector2(speedX + 1, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
						Main.projectile[proj1].hostile = false;
						Main.projectile[proj1].friendly = true;

						int proj2 = Projectile.NewProjectile(position, new Vector2(speedX, speedY - 1), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
						Main.projectile[proj2].hostile = false;
						Main.projectile[proj2].friendly = true;
					}
				}
			}
			if (BeeGlyph)
			{
				{
					if (Main.rand.Next(8) == 0)
					{
						int projType = Main.hardMode ? 35 : 20;
						int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 181, projType, 2f, player.whoAmI);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;

						proj = Projectile.NewProjectile(position, new Vector2(speedX + 1, speedY), 181, projType, 2f, player.whoAmI);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;

						proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY - 1), 181, projType, 2f, player.whoAmI);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;
					}
				}
			}
			if (modPlayer.manaWings)
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
			return true;
		}
	}
}
