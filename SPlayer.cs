using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod
{
	public class SPlayer : ModPlayer
	{
		public bool drakomireMount;

		public bool basiliskMount;

		public int drakomireFlameTimer;

		public bool unboundSoulMinion;

		public bool runicSet;

		public bool spiritSet;

		public bool goldenApple;

        public bool toxify = false;

		public override void ResetEffects()
		{
			this.drakomireMount = false;
			this.basiliskMount = false;
			this.unboundSoulMinion = false;
			this.runicSet = false;
			this.spiritSet = false;
			this.goldenApple = false;
            this.toxify = false;
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
        }
        public override void PostUpdateEquips()
		{
			if (this.runicSet)
			{
				this.SpawnRunicRunes();
			}
			else if (this.spiritSet)
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
			if (this.goldenApple)
			{
				int num2 = 20;
				float num3 = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * (float)num2;
				player.statDefense += (int)num3;
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

		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			if (this.basiliskMount)
			{
				int num = player.statDefense / 2;
				npc.StrikeNPCNoInteraction(num, 0f, 0, false, false, false);
			}
		}

		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			for (int i = 0; i < layers.Count; i++)
			{
				if ((this.drakomireMount || this.basiliskMount) && layers[i].Name == "Wings")
				{
					layers[i].visible = false;
				}
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
	}
}
