using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace SpiritMod
{
	public class MyPlayer : ModPlayer
	{ 
        public Entity LastEnemyHit = null;
		public bool hpRegenRing = false;
		public bool TiteRing = false;
		public bool NebulaPearl = false;
        public bool KingRock = false;
        private bool loaded = false;
		private const int saveVersion = 0;
		public bool minionName = false;
		public static bool hasProjectile;
		public bool DoomDestiny = false;
		public int HitNumber;
		public bool SRingOn = true;
		public bool ZoneSpirit = false;
		public bool ZoneVerdant = false;
		public bool PutridSetbonus = false;
		public int PutridHits = 0;
		public bool flametrail = false;
        public bool EnchantedPaladinsHammerMinion = false;
        public bool ProbeMinion = false;

        public override void UpdateBiomes()
		{
			ZoneSpirit = (MyWorld.SpiritTiles > 500);
			ZoneVerdant = (MyWorld.VerdantTiles > 400);
		}

		public override void ResetEffects()
		{
			SRingOn = false;
			minionName = false;
			NebulaPearl = false;
			hpRegenRing = false;
			TiteRing = false;
            this.infernalSet = false;
            KingRock = false;
			this.infernalShield = false;
			PutridSetbonus = false;
			flametrail = false;
            EnchantedPaladinsHammerMinion = false;
            ProbeMinion = false;

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
        LastEnemyHit = victim;
			base.OnHitAnything(x, y, victim);
		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (modPlayer.KingRock && Main.rand.Next(5) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 15, 0, Main.myPlayer);
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 15, 0, Main.myPlayer);
            }
			if (modPlayer.NebulaPearl && Main.rand.Next(8) == 2 && proj.magic)
            {
                Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, 3454);
            }
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
		}
		public override void PreUpdate()
		{
			//if (!loaded)
			//{
			//	Main.NewText("Thanks for using the Spirit Mod", 0, 191, 255);
			//	Main.NewText("Mod Website: ", 0, 191, 255);
			//	Main.NewText("http://forums.terraria.org/index.php?threads/the-spirit-mod.41395/", 0, 191, 255);
			//	loaded = true;
			//}
			if (flametrail == true && player.velocity.X != 0)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("CursedFlameTrail"), 100, 0f, player.whoAmI, 0f, 0f);
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
		public bool infernalSet;
		public int infernalSetCooldown;

		public bool infernalShield;
		public int infernalDash;
		public int infernalHit;

		public override void PostUpdateEquips()
		{
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
								player.velocity.X = -(float)hitDirection * 9f;
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
						player.velocity.X = 14.5f * (float)num21;
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
		}

		public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
		{
			if (npc.whoAmI == infernalHit)
			{
				damage = 0;
			}
		}
	}
}
