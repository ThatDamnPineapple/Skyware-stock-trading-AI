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

namespace SpiritMod
{
	public class MyPlayer : ModPlayer
    {
		public bool hungryMinion;
		public bool CrystalShield = false;
		public bool Phantom = false;
        public bool onGround = false;
        public bool moving = false;
        public bool flying = false;
		public bool BlueDust = false;
        public bool swimming = false;

        public bool copterBrake = false;
        public bool copterFiring = false;
        public int copterFireFrame = 1000;

        public int beetleStacks = 1;

        public bool unboundSoulMinion = false;

        float DistYT = 0f;
        float DistXT = 0f;
        float DistY = 0f;
        float DistX = 0f;
        public Entity LastEnemyHit = null;
		public bool TiteRing = false;
		public bool NebulaPearl = false;
		public bool CursedPendant = false;
		public bool IchorPendant = false;
        public bool KingRock = false;
        private bool loaded = false;
		private const int saveVersion = 0;
		public bool minionName = false;
		public static bool hasProjectile;
		public bool DoomDestiny = false;
		public int HitNumber;
		public bool ZoneSpirit = false;
		public bool ZoneVerdant = false;
		public int PutridHits = 0;
		public bool flametrail = false;
        public bool EnchantedPaladinsHammerMinion = false;
        public bool ProbeMinion = false;

        public int weaponAnimationCounter;
        public int hexBowAnimationFrame;

        public bool cragboundMinion;
        public bool carnivorousPlantMinion;

        public int soulSiphon;

        // Armor set booleans.
        public bool duskSet;
        public bool runicSet;
        public bool primalSet;
        public bool spiritSet;
        public bool putridSet;
        public bool leatherSet;
        public bool titanicSet;
        public bool infernalSet;
        public bool bloomwindSet;
        public bool veinstoneSet;
        public bool clatterboneSet;
        public bool talonSet;

        // Accessory booleans.
        public bool OriRing;
        public bool SRingOn;
        public bool goldenApple;
        public bool hpRegenRing;
        public bool bubbleShield;
        public bool mythrilCharm;
        public bool infernalShield;
        public bool shadowGauntlet;

        public int infernalHit;
        public int infernalDash;
        public int infernalSetCooldown;

        public int bubbleTimer;
        public int clatterboneTimer;

        public bool concentrated; // For the leather armor set.
        public int concentratedCooldown;

        public bool basiliskMount;
        public bool drakomireMount;

        public int drakomireFlameTimer;

        public bool toxify;

        public override void UpdateBiomes()
		{
			ZoneSpirit = (MyWorld.SpiritTiles > 500);
			ZoneVerdant = (MyWorld.VerdantTiles > 400);
		}

		public override void ResetEffects()
		{
			this.hungryMinion = false;
			CrystalShield = false;
			Phantom = false;
			IchorPendant = false;
			CursedPendant = false;
			BlueDust = false;
			minionName = false;
			NebulaPearl = false;
			TiteRing = false;
            KingRock = false;
			flametrail = false;
            EnchantedPaladinsHammerMinion = false;
            ProbeMinion = false;

            this.drakomireMount = false;
            this.basiliskMount = false;
            this.toxify = false;

            this.cragboundMinion = false;
            this.carnivorousPlantMinion = false;

            // Reset armor set booleans.
            this.duskSet = false;
            this.runicSet = false;
            this.primalSet = false;
            this.spiritSet = false;
            this.putridSet = false;
            this.leatherSet = false;
            this.titanicSet = false;
            this.infernalSet = false;
            this.bloomwindSet = false;
            this.veinstoneSet = false;
            this.clatterboneSet = false;
            this.talonSet = false;

            // Reset accessory booleans.
            this.OriRing = false;
            this.SRingOn = false;
            this.goldenApple = false;
            this.hpRegenRing = false;
            this.bubbleShield = false;
            this.mythrilCharm = false;
            this.infernalShield = false;
            this.shadowGauntlet = false;
            
            unboundSoulMinion = false;

            if (player.HasBuff(Buffs.BeetleFortitude._ref.Type) < 0)
            {
                beetleStacks = 1;
            }

            copterFireFrame++;

            onGround = false;
            moving = false;
            flying = false;
            swimming = false;

            if (player.velocity.Y != 0f)
            {
                if (player.mount.Active && player.mount.FlyTime > 0 && player.jump == 0 && player.controlJump && !player.mount.CanHover)
                {
                    flying = true;
                }
                else if (player.wet)
                {
                    swimming = true;
                }
            }
            else
            {
                onGround = true;
            }
            if (player.velocity.X != 0f)
            {
                moving = true;
            }
        }

		public override void OnHitAnything(float x, float y, Entity victim)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.TiteRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(10) == 2)
			{
				player.AddBuff(59, 145);
			}
			if (modPlayer.hpRegenRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(3) == 2)
			{
				player.AddBuff(58, 120);
			}
			if (modPlayer.OriRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(10) == 2)
			{
				 Vector2 mouse = new Vector2(victim.position.X, victim.position.Y);
            if (player.position.Y <= victim.position.Y)
            {
                float Xdis = player.position.X - victim.position.X;  // change myplayer to nearest player in full version
                float Ydis = player.position.Y - victim.position.Y; // change myplayer to nearest player in full version
                float Angle = (float)Math.Atan(Xdis / Ydis);
                DistXT = (float)(Math.Sin(Angle) * 300);
                DistYT = (float)(Math.Cos(Angle) * 300);
				DistX = (player.position.X + (0 - DistXT));
                DistY = (player.position.Y + (0 - DistYT));      
            }
            if (player.position.Y > victim.position.Y)
            {
                float Xdis = player.position.X - victim.position.X;  // change myplayer to nearest player in full version
                float Ydis = player.position.Y - victim.position.Y; // change myplayer to nearest player in full version
                float Angle = (float)Math.Atan(Xdis / Ydis);
                DistXT = (float)(Math.Sin(Angle) * 300);
                DistYT = (float)(Math.Cos(Angle) * 300);
                DistX = (player.position.X + DistXT);
                DistY = (player.position.Y + DistYT);
            }
			Vector2 direction = victim.Center - player.Center;
				direction.Normalize();
				direction.X *= 20f;
				direction.Y *= 20f;
				
						float A = (float)Main.rand.Next(-100, 100) * 0.01f;
						float B = (float)Main.rand.Next(-100, 100) * 0.01f;
           // Projectile.NewProjectile(DistX, DistY, (0 - DistX) / 50, (0 - DistY) / 50, mod.ProjectileType("ManaStarProjectile"), damage, knockBack, player.whoAmI, 0f, 0f);
            //return false;
			 Projectile.NewProjectile(DistX, DistY, direction.X + A, direction.Y + B, mod.ProjectileType("OriPetal"), 30, 1, player.whoAmI, 0f, 0f);
			}
        LastEnemyHit = victim;
			base.OnHitAnything(x, y, victim);
		}
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if(this.titanicSet && item.melee)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if(info.titanicSetStacks++ >= 4)
                {
                    Projectile newProj = Main.projectile[Projectile.NewProjectile(target.Center, Vector2.Zero, mod.ProjectileType("WaterMass"), 40, 2, player.whoAmI)];
                    newProj.timeLeft = 3;
                    newProj.netUpdate = true;

                    info.titanicSetStacks = 0;
                }
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (this.KingRock && Main.rand.Next(5) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 15, 0, Main.myPlayer);
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 15, 0, Main.myPlayer);
            }
			if (this.NebulaPearl && Main.rand.Next(8) == 2 && proj.magic)
            {
                Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, 3454);
            }
            if (this.titanicSet && proj.melee)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if (info.titanicSetStacks++ >= 4)
                {
                    Projectile newProj = Main.projectile[Projectile.NewProjectile(target.Center, Vector2.Zero, mod.ProjectileType("WaterMass"), 40, 2, player.whoAmI)];
                    newProj.timeLeft = 3;
                    newProj.netUpdate = true;

                    info.titanicSetStacks = 0;
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref string deathText)
        {
            if (this.bubbleTimer > 0)
                return false;
            if (player.HasBuff(mod.BuffType("Sturdy")) >= 0)
                return false;

            return true;
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (SRingOn == true)
			{
				for (int h = 0; h < 3; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 2f;
					int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, 297, 45, 0, Main.myPlayer);
				}
			}

            // IRIAZUL
            if(this.veinstoneSet && Main.rand.Next(10) == 0)
            {                
                int amount = Main.rand.Next(2, 5);
                for(int i = 0; i < amount; ++i)
                {
                    Vector2 position = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201), player.Center.Y - 600f);
                    position.X = (position.X * 10f + player.position.X) / 11f + (float)Main.rand.Next(-100, 101);
                    position.Y -= 150;
                    float speedX = player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201) - position.X;
                    float speedY = player.Center.Y - position.Y;
                    if (speedY < 0f)
                        speedY *= -1f;
                    if (speedY < 20f)
                        speedY = 20f;

                    float length = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
                    length = 12 / length;
                    speedX *= length;
                    speedY *= length;
                    speedX = speedX + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedY = speedY + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                    position.X += (float)Main.rand.Next(-50, 51);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("VeinstoneBlood"), 40, 1, player.whoAmI);
                }
            }

            if(this.mythrilCharm && Main.rand.Next(2) == 0)
            {
                int mythrilCharmDamage = (int)(damage / 4);
                if (mythrilCharmDamage < 1) mythrilCharmDamage = 5;

                Rectangle mythrilCharmCollision = new Rectangle((int)player.Center.X - 120, (int)player.Center.Y - 120, 240, 240);
                for(int i = 0; i < 200; ++i)
                {
                    if(Main.npc[i].active && Main.npc[i].Hitbox.Intersects(mythrilCharmCollision))
                    {
                        Main.npc[i].StrikeNPCNoInteraction(mythrilCharmDamage, 0, 0);
                    }
                }

                for(int i = 0; i < 15; ++i)
                {
                    Dust.NewDust(new Vector2(mythrilCharmCollision.X, mythrilCharmCollision.Y), mythrilCharmCollision.Width, mythrilCharmCollision.Height, DustID.LunarOre);
                }
            }
		}

		public override void PreUpdate()
		{
			if (flametrail == true && player.velocity.X != 0)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("CursedFlameTrail"), 35, 0f, player.whoAmI, 0f, 0f);
			}
			if (CrystalShield == true && player.velocity.X != 0 && Main.rand.Next(3) == 1)
			{
				if (player.velocity.X < 0)
				{
				Projectile.NewProjectile(player.position.X, player.Center.Y, Main.rand.Next(6,10), Main.rand.Next(-3,3), 90, 36, 0f, player.whoAmI, 0f, 0f);
				}
				if (player.velocity.X > 0)
				{
				Projectile.NewProjectile(player.position.X, player.Center.Y, Main.rand.Next(-10,-6), Main.rand.Next(-3,3), 90, 36, 0f, player.whoAmI, 0f, 0f);
			}
		}
		}

		public override void UpdateBadLifeRegen()
		{
			if (DoomDestiny)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 16;
			}
		}
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (SRingOn == true)
			{
				int newProj = Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y, (2 * 3), 2 * 3, 356, 40, 0f, Main.myPlayer);

				int dist = 800;
				int target = -1;
				for (int i = 0; i < 200; ++i)
				{
					if (Main.npc[i].active && Main.npc[i].CanBeChasedBy(Main.projectile[newProj], false))
					{
						if ((Main.npc[i].Center - Main.projectile[newProj].Center).Length() < dist)
						{
							target = i;
							break;
						}
					}
				}

				Main.projectile[newProj].ai[0] = target;
			}
		}

        // BELOW IS IRIAZUL'S SHIT ***BEWARE***

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref string deathText)
        {
            if(this.bubbleShield)
            {
                for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
                {
                    int type = player.armor[i].type;
                    if(type == mod.ItemType("BubbleShield"))
                    {
                        player.armor[i].SetDefaults(0);
                        break;
                    }
                }
                player.statLife = 150;
                bubbleTimer = 360;
                return false;
            }
            if(this.clatterboneSet)
            {
                if(this.clatterboneTimer <= 0)
                {
                    player.statLife += (int)damage;
                    this.clatterboneTimer = 36000; // 10 minute timer.

                    player.AddBuff(mod.BuffType("Sturdy"), 60);

                    return false;
                }
            }

            return true;
        }

        public override void PostUpdateEquips()
        {
            // Update armor sets.
            #region Infernal Set
            if (this.infernalSet)
            {
                int percentageLifeLeft = (int)(((float)player.statLife / (float)player.statLifeMax2) * 100);
                if (percentageLifeLeft <= 25)
                {
                    player.statDefense -= 4;
                    player.manaCost += 0.25F;
                    player.magicDamage += 0.5F;

                    bool spawnProj = true;
                    for (int i = 0; i < 1000; ++i)
                    {
                        if (Main.projectile[i].type == mod.ProjectileType("InfernalGuard") && Main.projectile[i].owner == player.whoAmI)
                        {
                            spawnProj = false;
                            break;
                        }
                    }
                    if (spawnProj)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            int newProj = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("InfernalGuard"), 0, 0, player.whoAmI, 90, 1);
                            Main.projectile[newProj].localAI[1] = 2f * (float)Math.PI / 3f * i;
                        }
                    }

                    player.AddBuff(mod.BuffType("InfernalRage"), 2);
                    infernalSetCooldown = 60;
                }
            }

            if (infernalSetCooldown > 0)
                infernalSetCooldown--;
            #endregion

            if (this.runicSet)
            {
                this.SpawnRunicRunes();
            }

            #region Spirit Set
            if (this.spiritSet)
            {
                if (Main.rand.Next(5) == 0)
                {
                    int num = Dust.NewDust(player.position, player.width, player.height, 261, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num].noGravity = true;
                }
                if (player.statLife >= 400)
                {
                    player.meleeDamage += 0.05f;
                    player.magicDamage += 0.05f;
                    player.minionDamage += 0.05f;
                    player.thrownDamage += 0.05f;
                    player.rangedDamage += 0.05f;
                }
                else if (player.statLife >= 200)
                {
                    player.statDefense += 5;
                }
                else if (player.statLife >= 50)
                {
                    player.lifeRegenTime += 2;
                }
                else if (player.statLife > 0)
                {
                    player.noKnockback = true;
                }
            }
            #endregion

            if (this.bloomwindSet)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("BloomwindMinion")] <= 0)
                {
                    player.AddBuff(mod.BuffType("BloomwindMinionBuff"), 3600);
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("BloomwindMinion"), 25, 0, player.whoAmI);
                }
            }

            if (this.leatherSet)
            {
                if (this.concentratedCooldown > 0)
                    this.concentratedCooldown--;
            }
            if (!this.leatherSet)
            {
                this.concentrated = false;
                this.concentratedCooldown = 300;
            }

            // Update accessories.
            #region Infernal Shield
            if (this.infernalShield)
            {
                if (infernalDash > 0)
                    infernalDash--;
                else
                    infernalHit = -1;

                if (infernalDash > 0 && infernalHit < 0)
                {
                    Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                        {
                            NPC npc = Main.npc[i];
                            Rectangle rect = npc.getRect();
                            if (rectangle.Intersects(rect) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                            {
                                float damage = 30f * player.meleeDamage;
                                float knockback = 9f;
                                bool crit = false;

                                if (player.kbGlove)
                                    knockback *= 2f;
                                if (player.kbBuff)
                                    knockback *= 1.5f;

                                if (Main.rand.Next(100) < player.meleeCrit)
                                    crit = true;

                                int hitDirection = player.direction;
                                if (player.velocity.X < 0f)
                                {
                                    hitDirection = -1;
                                }
                                if (player.velocity.X > 0f)
                                {
                                    hitDirection = 1;
                                }
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    npc.AddBuff(mod.BuffType("StackingFireBuff"), 600);
                                    npc.StrikeNPC((int)damage, knockback, hitDirection, crit, false, false);
                                    if (Main.netMode != 0)
                                    {
                                        NetMessage.SendData(28, -1, -1, "", i, damage, knockback, (float)hitDirection, 0, 0, 0);
                                    }
                                }

                                this.infernalDash = 10;
                                player.dashDelay = 30;
                                player.velocity.X = -(float)hitDirection * 18f;
                                player.velocity.Y = -4f;
                                player.immune = true;
                                player.immuneTime = 4;
                                this.infernalHit = i;
                            }
                        }
                    }
                }

                if (player.dash <= 0 && player.dashDelay == 0 && !player.mount.Active)
                {
                    int num21 = 0;
                    bool flag2 = false;
                    if (player.dashTime > 0)
                        player.dashTime--;
                    if (player.dashTime < 0)
                        player.dashTime++;

                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num21 = 1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = 15;
                        }
                    } else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num21 = -1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = -15;
                        }
                    }

                    if (flag2)
                    {
                        player.velocity.X = 15.5f * (float)num21;
                        Point point3 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                        Point point4 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), 0f)).ToTileCoordinates();
                        if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = -1;
                        this.infernalDash = 15;
                        for (int num22 = 0; num22 < 0; num22++)
                        {
                            int num23 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
                            Dust dust3 = Main.dust[num23];
                            dust3.position.X = dust3.position.X + (float)Main.rand.Next(-5, 6);
                            Dust dust4 = Main.dust[num23];
                            dust4.position.Y = dust4.position.Y + (float)Main.rand.Next(-5, 6);
                            Main.dust[num23].velocity *= 0.2f;
                            Main.dust[num23].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                            Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(player.shield, player);
                        }
                    }
                }
            }

            if (infernalDash > 0)
                infernalDash--;
            if (player.dashDelay < 0)
            {
                for (int l = 0; l < 0; l++)
                {
                    int num14;
                    if (player.velocity.Y == 0f)
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
                    } else
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (player.height / 2) - 8f), player.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
                    }
                    Main.dust[num14].velocity *= 0.1f;
                    Main.dust[num14].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                    Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.shoe, player);
                }

                float maxSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);

                player.vortexStealthActive = false;
                if (player.velocity.X > 12f || player.velocity.X < -12f)
                {
                    player.velocity.X = player.velocity.X * 0.985f;
                    return;
                }
                if (player.velocity.X > maxSpeed || player.velocity.X < -maxSpeed)
                {
                    player.velocity.X = player.velocity.X * 0.94f;
                    return;
                }
                player.dashDelay = 30;
                if (player.velocity.X < 0f)
                {
                    player.velocity.X = -maxSpeed;
                    return;
                }
                if (player.velocity.X > 0f)
                {
                    player.velocity.X = maxSpeed;
                    return;
                }
            }
            #endregion

            if (this.shadowGauntlet)
            {
                player.kbGlove = true;
                player.meleeDamage += 0.07F;
                player.meleeSpeed += 0.07F;
            }
            if (this.goldenApple)
            {
                int num2 = 20;
                float num3 = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * (float)num2;
                player.statDefense += (int)num3;
            }
            if (this.bubbleTimer > 0)
                this.bubbleTimer--;

            if (this.soulSiphon > 0)
            {
                player.lifeRegenTime += 2;
                int num = (5 + this.soulSiphon) / 2;
                player.lifeRegenTime += num;
                player.lifeRegen += num;

                this.soulSiphon = 0;
            }

            if (this.drakomireMount)
            {
                player.statDefense += 40;
                player.noKnockback = true;
                if (player.dashDelay > 0)
                {
                    player.dashDelay--;
                }
                else
                {
                    int num4 = 0;
                    bool flag = false;
                    if (player.dashTime > 0)
                    {
                        player.dashTime--;
                    }
                    else if (player.dashTime < 0)
                    {
                        player.dashTime++;
                    }
                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num4 = 1;
                            flag = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = 15;
                        }
                    }
                    else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num4 = -1;
                            flag = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = -15;
                        }
                    }
                    if (flag)
                    {
                        player.velocity.X = 16.9f * (float)num4;
                        Point point = Utils.ToTileCoordinates(player.Center + new Vector2((float)(num4 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f));
                        Point point2 = Utils.ToTileCoordinates(player.Center + new Vector2((float)(num4 * player.width / 2 + 2), 0f));
                        if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = 600;
                    }
                }
                if (player.velocity.X != 0f && player.velocity.Y == 0f)
                {
                    this.drakomireFlameTimer += (int)Math.Abs(player.velocity.X);
                    if (this.drakomireFlameTimer >= 15)
                    {
                        Vector2 vector = player.Center + new Vector2((float)(26 * -(float)player.direction), 26f * player.gravDir);
                        Terraria.Projectile.NewProjectile(vector.X, vector.Y, 0f, 0f, mod.ProjectileType("DrakomireFlame"), player.statDefense / 2, 0f, player.whoAmI, 0f, 0f);
                        this.drakomireFlameTimer = 0;
                    }
                }
                if (Main.rand.Next(10) == 0)
                {
                    Vector2 vector2 = player.Center + new Vector2((float)(-48 * player.direction), -6f * player.gravDir);
                    if (player.direction == -1)
                    {
                        vector2.X -= 20f;
                    }
                    Dust.NewDust(vector2, 16, 16, 6, 0f, 0f, 0, default(Color), 1f);
                }
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
			if (CursedPendant && Main.rand.Next(5) == 1)
			{
				target.AddBuff(39, 180);
			}
			if (IchorPendant && Main.rand.Next(10) == 1)
			{
				target.AddBuff(69, 180);
			}
            if (this.shadowGauntlet)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 180);
            }
            if (this.duskSet && item.magic)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 300);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (this.shadowGauntlet && proj.melee)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 180);
            }
            if (this.duskSet && proj.magic)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 300);
            }
            
            if(this.concentrated && proj.ranged)
            {
                damage = (int)(damage * 1.1F);
                crit = true;

                this.concentrated = false;
                this.concentratedCooldown = 300;
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (this.shadowGauntlet && item.melee)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (npc.whoAmI == infernalHit)
            {
                damage = 0;
            }
        }

        public override void FrameEffects()
        {
            //Hide players wings, etc. when mounted
            if (player.mount.Active)
            {
                int mount = player.mount.Type;
                if (mount == CandyCopter._ref.Type)
                {
                    //Supposed to make players legs disappear, but only makes them skin-colored.
                    player.legs = CandyCopter._outfit;
                    player.wings = -1;
                    player.back = -1;
                    player.shield = -1;
                    //player.handoff = -1;
                    //player.handon = -1;
                }
                else if (mount == Drakomire._ref.Type)
                {
                    player.wings = -1;
                }
            }
        }

        public override void PostUpdateRunSpeeds()
        {
            if (copterBrake && player.mount.Active && player.mount.Type == CandyCopter._ref.Type)
            {
                //Prevent horizontal movement
                player.maxRunSpeed = 0f;
                player.runAcceleration = 0f;
                //Deplete horizontal velocity
                if (player.velocity.X > CandyCopter.groundSlowdown)
                {
                    player.velocity.X -= CandyCopter.groundSlowdown;
                }
                else if (player.velocity.X < -CandyCopter.groundSlowdown)
                {
                    player.velocity.X += CandyCopter.groundSlowdown;
                }
                else
                {
                    player.velocity.X = 0f;
                }
                //Prevent further depletion by game engine
                player.runSlowdown = 0f;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (toxify)
            {
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width + 4, 30, 110, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
			if (BlueDust)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width + 4, 30, 206, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (this.basiliskMount)
            {
                int num = player.statDefense / 2;
                npc.StrikeNPCNoInteraction(num, 0f, 0, false, false, false);
            }
        }

        private void SpawnRunicRunes()
        {
            int num = 80;
            float num2 = 1.5f;
            int num3 = mod.ProjectileType("RunicRune");
            if (Main.rand.Next(15) == 0)
            {
                int num4 = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].type == num3)
                    {
                        num4++;
                    }
                }
                if (Main.rand.Next(15) >= num4 && num4 < 10)
                {
                    int num5 = 50;
                    int num6 = 24;
                    int num7 = 90;
                    for (int j = 0; j < num5; j++)
                    {
                        int num8 = Main.rand.Next(200 - j * 2, 400 + j * 2);
                        Vector2 center = player.Center;
                        center.X += (float)Main.rand.Next(-num8, num8 + 1);
                        center.Y += (float)Main.rand.Next(-num8, num8 + 1);
                        if (!Collision.SolidCollision(center, num6, num6) && !Collision.WetCollision(center, num6, num6))
                        {
                            center.X += (float)(num6 / 2);
                            center.Y += (float)(num6 / 2);
                            if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
                            {
                                int num9 = (int)center.X / 16;
                                int num10 = (int)center.Y / 16;
                                bool flag = false;
                                if (Main.rand.Next(3) == 0 && Main.tile[num9, num10] != null && Main.tile[num9, num10].wall > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    center.X -= (float)(num7 / 2);
                                    center.Y -= (float)(num7 / 2);
                                    if (Collision.SolidCollision(center, num7, num7))
                                    {
                                        center.X += (float)(num7 / 2);
                                        center.Y += (float)(num7 / 2);
                                        flag = true;
                                    }
                                }
                                if (flag)
                                {
                                    for (int k = 0; k < 1000; k++)
                                    {
                                        if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == num3 && (center - Main.projectile[k].Center).Length() < 48f)
                                        {
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag && Main.myPlayer == player.whoAmI)
                                    {
                                        Terraria.Projectile.NewProjectile(center.X, center.Y, 0f, 0f, num3, num, num2, player.whoAmI, 0f, 0f);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Player Draw Layers
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if ((this.drakomireMount || this.basiliskMount) && layers[i].Name == "Wings")
                {
                    layers[i].visible = false;
                }

                if(layers[i].Name == "HeldItem")
                {
                    if(player.inventory[player.selectedItem].type == mod.ItemType("HexBow") && player.itemAnimation > 0)
                    {
                        this.weaponAnimationCounter++;
                        if(this.weaponAnimationCounter >= 10)
                        {
                            this.hexBowAnimationFrame =  (this.hexBowAnimationFrame + 1) % 4;
                            weaponAnimationCounter = 0;
                        }
                        layers[i] = WeaponLayer;
                    }
                }
            }

            if(this.bubbleTimer > 0)
            {
                BubbleLayer.visible = true;
                layers.Add(BubbleLayer);
            }
        }

        public static readonly PlayerLayer WeaponLayer = new PlayerLayer("SpiritMod", "WeaponLayer", PlayerLayer.HeldItem, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("SpiritMod");
            MyPlayer mp = drawPlayer.GetModPlayer<MyPlayer>(mod);

            if (drawPlayer.active && !drawPlayer.outOfRange)
            {
                Texture2D weaponTexture = Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type];
                SpriteEffects effect = drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Vector2 vector8 = new Vector2(weaponTexture.Width / 2, (weaponTexture.Height / 4) / 2);
                Vector2 vector9 = new Vector2(8, 0);
                int num84 = (int)vector9.X;
                Vector2 vector = drawPlayer.itemLocation;
                vector.Y += weaponTexture.Height * 0.5F;
                vector8.Y = vector9.Y;
                Vector2 origin2 = new Vector2(-(float)num84, (weaponTexture.Height / 4) / 2);
                if (drawPlayer.direction == -1)
                {
                    origin2 = new Vector2((float)(weaponTexture.Width + num84), (weaponTexture.Height / 4) / 2);
                }
                DrawData drawData = new DrawData(weaponTexture, new Vector2((float)((int)(vector.X - Main.screenPosition.X + vector8.X)), (float)((int)(vector.Y - Main.screenPosition.Y + vector8.Y))), new Rectangle?(new Rectangle(0, (weaponTexture.Height / 4) * mp.hexBowAnimationFrame, weaponTexture.Width, weaponTexture.Height / 4)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(Color.White), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effect, 0);
                Main.playerDrawData.Add(drawData);
                if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Color))
                {
                    drawData = new DrawData(weaponTexture, new Vector2((float)((int)(vector.X - Main.screenPosition.X + vector8.X)), (float)((int)(vector.Y - Main.screenPosition.Y + vector8.Y))), new Rectangle?(new Rectangle(0, (weaponTexture.Height / 4) * mp.hexBowAnimationFrame, weaponTexture.Width, weaponTexture.Height / 4)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(Color.White), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effect, 0);
                    Main.playerDrawData.Add(drawData);
                }
            }
        });

        public static readonly PlayerLayer BubbleLayer = new PlayerLayer("SpiritMod", "BubbleLayer", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("SpiritMod");

            if (drawPlayer.active && !drawPlayer.outOfRange)
            {
                Texture2D texture = mod.GetTexture("Effects/PlayerVisuals/BubbleShield_Visual");
                Vector2 drawPos = drawPlayer.position + new Vector2(drawPlayer.width * 0.5F, drawPlayer.height * 0.5F);
                drawPos.X = (int)drawPos.X; drawPos.Y = (int)drawPos.Y;
                Vector2 origin = new Vector2(texture.Width * 0.5F, texture.Height * 0.5F);
                DrawData drawData = new DrawData(texture, drawPos - Main.screenPosition, new Rectangle?(), Color.White * 0.75F, 0, origin, 1, SpriteEffects.None, 0);
                Main.playerDrawData.Add(drawData);
            }
        });
        #endregion
    }
}
