using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod.Items
{
	public class GItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		public override bool CloneNewInstances => true;

		bool CandyToolTip = false;

		private GlyphType glyph = 0;
		public GlyphType Glyph => glyph;
		public void SetGlyph(Item item, GlyphType glyph)
		{
			if (this.glyph == glyph)
				return;
			AdjustStats(item, true);
			this.glyph = glyph;
			AdjustStats(item);
		}

		private void AdjustStats(Item item, bool remove = false)
		{
			Item norm = new Item();
			norm.netDefaults(item.netID);

			float damage = 0;
			int crit = 0;
			float mana = 0;
			float knockBack = 0;
			float velocity = 0;
			float useTime = 0;
			float size = 0;

			if (glyph == GlyphType.Frost)
				crit += 6;
			else if (glyph == GlyphType.Poison)
				crit += 5;
			else if (glyph == GlyphType.Scorch)
			{
				velocity += 1;
			}

			int s = remove ? -1 : 1;
			item.damage += s * (int)Math.Round(norm.damage * damage);
			item.useAnimation += s * (int)Math.Round(norm.useAnimation * useTime);
			item.useTime += s * (int)Math.Round(norm.useTime * useTime);
			item.reuseDelay += s * (int)Math.Round(norm.reuseDelay * useTime);
			item.mana += s * (int)Math.Round(norm.mana * mana);
			item.knockBack += s * norm.knockBack * knockBack;
			item.scale += s * norm.scale * size;
			item.shootSpeed += s * norm.shootSpeed * velocity;
			item.crit += s * crit;
			if (remove)
			{
				if (item.knockBack > norm.knockBack - .0001 &&
					item.knockBack < norm.knockBack + .0001)
					item.knockBack = norm.knockBack;
				if (item.scale > norm.scale - .0001 &&
					item.scale < norm.scale + .0001)
					item.scale = norm.scale;
				if (item.shootSpeed > norm.shootSpeed - .0001 &&
					item.shootSpeed < norm.shootSpeed + .0001)
					item.shootSpeed = norm.shootSpeed;
			}
		}


		public override bool NeedsSaving(Item item)
		{
			return glyph != GlyphType.None;
		}

		public override TagCompound Save(Item item)
		{
			TagCompound data = new TagCompound();
			data.Add("glyph", (int)glyph);
			return data;
		}

		public override void Load(Item item, TagCompound data)
		{
			glyph = (GlyphType)data.GetInt("glyph");
			AdjustStats(item);
		}

		public override void NetSend(Item item, BinaryWriter writer)
		{
			writer.Write((byte)glyph);
		}

		public override void NetReceive(Item item, BinaryReader reader)
		{
			glyph = (GlyphType)reader.ReadByte();
			AdjustStats(item);
		}


		public override void PostReforge(Item item)
		{
			glyph = 0;
			AdjustStats(item);
		}


		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context != "goodieBag")
				return;
			_ItemUtils.DropCandy(player);
			if (Main.rand.Next(3) == 0)
			{
				string[] lootTable = { "MaskSchmo", "MaskGraydee", "MaskLordCake", "MaskVladimier", "MaskKachow", "MaskHulk", "MaskBlaze", "MaskSvante", "MaskIggy", "MaskYuyutsu", "MaskLeemyy", };
				int loot = Main.rand.Next(lootTable.Length);
				player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
			}
		}


		public override void HoldItem(Item item, Player player)
		{
			switch (glyph)
			{
				case GlyphType.Frost:
					if (player.ownedProjectileCounts[Projectiles.FreezeProj._type] <= 1)
						Projectile.NewProjectile(player.position, Vector2.Zero, Projectiles.FreezeProj._type, 0, 0, player.whoAmI);
					break;
				case GlyphType.Scorch:
					if (player.itemAnimation != 0)
						player.AddBuff(BuffID.OnFire, 129);
					break;
				case GlyphType.Void:
					player.AddBuff(Buffs.Glyph.VoidGlyphBuff._type, 2);
					break;
			}
		}


		public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (glyph == GlyphType.Daze)
				Glyphs.DazeGlyph.Daze(target, ref damage);
		}

		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
		{
			switch (glyph)
			{
				case GlyphType.Poison:
					if (crit)
						Glyphs.PoisonGlyph.ReleasePoisonClouds(target, player.whoAmI);
					break;
				case GlyphType.Blood:
					Glyphs.BloodGlyph.BloodCorruption(player, target);
					break;
				case GlyphType.Scorch:
					Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case GlyphType.Bee:
					Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case GlyphType.Void:
					Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}
		}

		public override void ModifyHitPvp(Item item, Player player, Player target, ref int damage, ref bool crit)
		{
			if (glyph == GlyphType.Daze)
				Glyphs.DazeGlyph.Daze(target, ref damage);
		}

		public override void OnHitPvp(Item item, Player player, Player target, int damage, bool crit)
		{
			switch (glyph)
			{
				case GlyphType.Poison:
					if (crit)
						Glyphs.PoisonGlyph.ReleasePoisonClouds(target, player.whoAmI);
					break;
				case GlyphType.Blood:
					Glyphs.BloodGlyph.BloodCorruption(player, target);
					break;
				case GlyphType.Scorch:
					Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case GlyphType.Bee:
					Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case GlyphType.Void:
					Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}
		}


		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.talonSet && (item.ranged || item.magic) && Main.rand.Next(10) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY + 2), ProjectileID.HarpyFeather, 10, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.titanicSet && item.melee && Main.rand.Next(6) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WaterMass"), 40, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.fierySet && (item.ranged || item.thrown) && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.Fireball, 16, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.cultistScarf && item.magic && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WildMagic"), 66, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.thermalSet && item.melee && Main.rand.Next(6) == 0)
			{
				for (int I = 0; I < 4; I++)
				{
					int proj = Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(300, 500) / 100), speedY * (Main.rand.Next(300, 500) / 100), 134, 65, 7f, player.whoAmI, 0f, 0f);
					Main.projectile[proj].friendly = true;
					Main.projectile[proj].hostile = false;
				}
			}
			if (modPlayer.timScroll && item.magic && Main.rand.Next(12) == 0)
			{
				int p = Main.rand.Next(9, 22);
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, p, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
			}
			if (modPlayer.crystal && item.ranged && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX * (float)(Main.rand.Next(100, 165) / 100), speedY * (float)(Main.rand.Next(100, 165) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
			}

			if (modPlayer.KingSlayerFlask && item.thrown && Main.rand.Next(5) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("KingSlayerKnife"), 35, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			if (modPlayer.fireMaw && item.ranged && Main.rand.Next(10) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("FireMaw"), 30, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			if (modPlayer.drakinMount && item.magic && Main.rand.Next(4) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 671, 41, 3f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.MoonSongBlossom && item.ranged && Main.rand.Next(8) == 0)
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
			if (modPlayer.manaWings && item.magic && Main.rand.Next(7) == 0)
			{
				float d1 = 20 + ((player.statManaMax2 - player.statMana) / 3);
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("ManaSpark"), (int)d1, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			return true;
		}


		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			string line = null;
			Color color = Color.White;
			switch (glyph)
			{
				case GlyphType.Frost:
					line = "[Frostfreeze]\n"+
						"Increases critical strike chance by 6%\n"+
						"Enemies near you are slowed";
					color = new Color(80, 80, 200);
					break;
				case GlyphType.Poison:
					line = "[Rotting Wounds]\n"+
						"Increases critical strike chance by 5%\n"+
						"Landing critical strikes on foes may release poisonous clouds";
					color = new Color(80, 200, 80);
					break;
				case GlyphType.Blood:
					line = "[Sanguine Strike]\n"+
						"Attacks inflict Blood Corruption\n"+
						"Hitting enemies with Blood Corruption may steal life";
					color = new Color(200, 80, 80);
					break;
				case GlyphType.Scorch:
					line = "[Flare Frenzy]\n"+
						"The player is engulfed in flames\n"+
						"Greatly increases the velocity of projectiles\n"+
						"Attacks may inflict On Fire\n"+
						"Attacks may also deal extra damage";
					color = new Color(255, 153, 10);
					break;
				case GlyphType.Bee:
					line = "[Wasp Call]\n"+
						"Reduces movement speed by 7%\n"+
						"Attacks may release multiple bees";
					color = new Color(158, 125, 10);
					break;
				case GlyphType.Phase:
					line = "[Phase Flux]\n"+
						"20% increased movement speed\n"+
						"Grants immunity to knockback\n"+
						"Reduces defense by 5";
					color = new Color(255, 217, 30);
					break;
				case GlyphType.Daze:
					line = "[Dazed Dance]\n"+
						"All attacks inflict confusion\n"+
						"Confused enemies take extra damage\n"+
						"Getting hurt may confuse the player";
					color = new Color(163, 22, 224);
					break;
				case GlyphType.Camo:
					line = "[Concealment]\n"+
						"Being still puts you in stealth\n"+
						"Stealth increases damage by 15% and life regen by 3";
					color = new Color(22, 188, 127);
					break;
				case GlyphType.Void:
					line = "[Collapsing Void]\n"+
						"Grants you Collapsing Void, which reduces damage taken by 5%\n"+
						"Crits on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\n"+
						"Hitting foes when having more than one stack of Collapsing Void may generate Void Stars";
					color = new Color(120, 31, 209);
					break;
				case GlyphType.Haunt:
					line = "[Haunting]\n"+
						"Attacks cause fear inducing bats to sweep across the screen\n"+
						"You deal 8% additional damage to feared enemies";
					color = new Color(120, 170, 170);
					break;
			}
			if (line != null)
			{
				TooltipLine tip = new TooltipLine(mod, "Glyph", line);
				tip.overrideColor = color;
				tooltips.Add(tip);
			}

			if (glyph != GlyphType.None && item.prefix <= 0)
				InsertStatInfo(item, tooltips);
		}

		private void InsertStatInfo(Item item, List<TooltipLine> tooltips)
		{
			int index = 0;
			for (int i = tooltips.Count - 1; i >= 0; i--)
			{
				TooltipLine curr = tooltips[i];
				if (curr.mod != "Terraria")
					continue;
				if (curr.Name == "Price" ||
					curr.Name == "Expert" ||
					curr.Name == "SetBonus")
					continue;

				index = i + 1;
				break;
			}

			Item compare = new Item();
			compare.netDefaults(item.netID);
			string line;
			TooltipLine tip;

			if (compare.damage != item.damage)
			{
				double damage = (double)((float)item.damage - (float)compare.damage);
				damage = damage / (double)((float)compare.damage) * 100.0;
				damage = Math.Round(damage);
				if (damage > 0.0)
					line = "+" + damage + Lang.tip[39];
				else
					line = damage.ToString() + Lang.tip[39];

				tip = new TooltipLine(mod, "PrefixDamage", line);
				if (damage < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.useAnimation != item.useAnimation)
			{
				double speed = (double)((float)item.useAnimation - (float)compare.useAnimation);
				speed = speed / (double)((float)compare.useAnimation) * 100.0;
				speed = Math.Round(speed);
				speed *= -1.0;
				if (speed > 0.0)
					line = "+" + speed + Lang.tip[40];
				else
					line = speed.ToString() + Lang.tip[40];

				tip = new TooltipLine(mod, "PrefixSpeed", line);
				if (speed < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.crit != item.crit)
			{
				double crit = (double)((float)item.crit - (float)compare.crit);
				if (crit > 0.0)
					line = "+" + crit + Lang.tip[41];
				else
					line = crit.ToString() + Lang.tip[41];

				tip = new TooltipLine(mod, "PrefixCritChance", line);
				if (crit < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.mana != item.mana)
			{
				double mana = (double)((float)item.mana - (float)compare.mana);
				mana = mana / (double)((float)compare.mana) * 100.0;
				mana = Math.Round(mana);
				if (mana > 0.0)
					line = "+" + mana + Lang.tip[42];
				else
					line = mana.ToString() + Lang.tip[42];

				tip = new TooltipLine(mod, "PrefixUseMana", line);
				if (mana > 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.scale != item.scale)
			{
				double scale = (double)(item.scale - compare.scale);
				scale = scale / (double)compare.scale * 100.0;
				scale = Math.Round(scale);
				if (scale > 0.0)
					line = "+" + scale + Lang.tip[43];
				else
					line = scale.ToString() + Lang.tip[43];

				tip = new TooltipLine(mod, "PrefixSize", line);
				if (scale < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.shootSpeed != item.shootSpeed)
			{
				double velocity = (double)(item.shootSpeed - compare.shootSpeed);
				velocity = velocity / (double)compare.shootSpeed * 100.0;
				velocity = Math.Round(velocity);
				if (velocity > 0.0)
					line = "+" + velocity + Lang.tip[44];
				else
					line = velocity.ToString() + Lang.tip[44];

				tip = new TooltipLine(mod, "PrefixShootSpeed", line);
				if (velocity < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}

			if (compare.knockBack != item.knockBack)
			{
				double knockback = (double)(item.knockBack - compare.knockBack);
				knockback = knockback / (double)compare.knockBack * 100.0;
				knockback = Math.Round(knockback);
				if (knockback > 0.0)
					line = "+" + knockback + Lang.tip[45];
				else
					line = knockback.ToString() + Lang.tip[45];

				tip = new TooltipLine(mod, "PrefixKnockback", line);
				if (knockback < 0.0)
					tip.isModifierBad = true;

				tip.isModifier = true;
				tooltips.Insert(index++, tip);
			}
		}


		private static readonly Vector2 SlotDimensions = new Vector2(52, 52);
		public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if (glyph == GlyphType.None)
				return;

			float slotScale = 1f;
			if (frame.Width > 32 || frame.Height > 32)
			{
				if (frame.Width > frame.Height)
					slotScale = 32f / frame.Width;
				else
					slotScale = 32f / frame.Height;
			}
			slotScale *= Main.inventoryScale;
			Vector2 slotOrigin = position + frame.Size() * (.5f * slotScale);
			slotOrigin -= SlotDimensions * (.5f * Main.inventoryScale);

			Texture2D texture = GlyphOverlay();
			if (texture != null)
			{
				Vector2 offset = SlotDimensions;
				offset -= texture.Size();
				offset -= new Vector2(4f);
				offset *= Main.inventoryScale;
				//offset += new Vector2(40f, 40f) * Main.inventoryScale;//stack offset Vector2(10f, 26f)
				spriteBatch.Draw(texture, slotOrigin + offset, null, drawColor, 0f, Vector2.Zero, Main.inventoryScale, SpriteEffects.None, 0f);
			}
		}

		public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			if (glyph == GlyphType.None)
				return;

			Texture2D texture = GlyphOverlay();
			Color glowColor = new Color(250, 250, 250, item.alpha);
			Vector2 position = item.position - Main.screenPosition;
			position.X += (item.width >> 1);
			position.Y += 2 + item.height - (Main.itemTexture[item.type].Height >> 1);

			//Color alpha = Color.Lerp(alphaColor, glowColor, .2f);
			Color alpha = alphaColor;
			alpha.R = (byte)Math.Min(alpha.R + 25, 255);
			alpha.G = (byte)Math.Min(alpha.G + 25, 255);
			alpha.B = (byte)Math.Min(alpha.B + 25, 255);
			//alpha.A = (byte)(alpha.A * .6f);
			Vector2 origin = new Vector2(texture.Width >> 1, texture.Height >> 1);
			Main.spriteBatch.Draw(texture, position, null, alpha, rotation, origin, scale, SpriteEffects.None, 0f);
		}

		public Texture2D GlyphOverlay()
		{
			switch (glyph)
			{
				case GlyphType.Frost:
					return Glyphs.FrostGlyph._textures[1];
				case GlyphType.Poison:
					return Glyphs.PoisonGlyph._textures[1];
				case GlyphType.Blood:
					return Glyphs.BloodGlyph._textures[1];
				case GlyphType.Scorch:
					return Glyphs.ScorchGlyph._textures[1];
				case GlyphType.Phase:
					return Glyphs.PhaseGlyph._textures[1];
				case GlyphType.Daze:
					return Glyphs.DazeGlyph._textures[1];
				case GlyphType.Void:
					return Glyphs.VoidGlyph._textures[1];
			}
			return null;
		}
	}
}
