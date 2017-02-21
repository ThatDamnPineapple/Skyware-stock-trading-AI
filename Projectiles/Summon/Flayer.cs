using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Projectiles.Summon;

namespace SpiritMod.Projectiles.Summon
{
	public class Flayer : Minion
	{
		public override void SetDefaults()
		{
			base.projectile.name = "Miniflayer";
			base.projectile.width = 32;
			base.projectile.height = 32;
			Main.projFrames[base.projectile.type] = 1;
			Main.projPet[base.projectile.type] = true;
			base.projectile.friendly = true;
			base.projectile.minion = true;
			base.projectile.minionSlots = 1f;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 18000;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.Homing[base.projectile.type] = true;
			base.projectile.netImportant = true;
		}

		public override void CheckActive()
		{
			MyPlayer mp = Main.player[base.projectile.owner].GetModPlayer<MyPlayer>(base.mod);
			if (mp.player.dead)
			{
                mp.Flayer = false;
			}
			if (mp.Flayer)
			{
				projectile.timeLeft = 2;
			}
		}

		public override void Behavior()
		{
			Player player = Main.player[base.projectile.owner];
			float num = (float)base.projectile.width * 1.1f;
			for (int i = 0; i < 1000; i++)
			{
				Terraria.Projectile projectile = Main.projectile[i];
				if (i != base.projectile.whoAmI && projectile.active && projectile.owner == base.projectile.owner && projectile.type == base.projectile.type && Math.Abs(base.projectile.position.X - projectile.position.X) + Math.Abs(base.projectile.position.Y - projectile.position.Y) < num)
				{
					if (base.projectile.position.X < Main.projectile[i].position.X)
					{
						Terraria.Projectile expr_F3_cp_0 = base.projectile;
						expr_F3_cp_0.velocity.X = expr_F3_cp_0.velocity.X - 0.08f;
					}
					else
					{
						Terraria.Projectile expr_111_cp_0 = base.projectile;
						expr_111_cp_0.velocity.X = expr_111_cp_0.velocity.X + 0.08f;
					}
					if (base.projectile.position.Y < Main.projectile[i].position.Y)
					{
						Terraria.Projectile expr_150_cp_0 = base.projectile;
						expr_150_cp_0.velocity.Y = expr_150_cp_0.velocity.Y - 0.08f;
					}
					else
					{
						Terraria.Projectile expr_16E_cp_0 = base.projectile;
						expr_16E_cp_0.velocity.Y = expr_16E_cp_0.velocity.Y + 0.08f;
					}
				}
			}
			Vector2 value = base.projectile.position;
			float num2 = 500f;
			bool flag = false;
			base.projectile.tileCollide = true;
			for (int j = 0; j < 200; j++)
			{
				NPC nPC = Main.npc[j];
				if (nPC.CanBeChasedBy(this, false))
				{
					float num3 = Vector2.Distance(nPC.Center, base.projectile.Center);
					if ((num3 < num2 || !flag) && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, nPC.position, nPC.width, nPC.height))
					{
						num2 = num3;
						value = nPC.Center;
						flag = true;
					}
				}
			}
			if (Vector2.Distance(player.Center, base.projectile.Center) > (flag ? 1000f : 500f))
			{
				base.projectile.ai[0] = 1f;
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[0] == 1f)
			{
				base.projectile.tileCollide = false;
			}
			if (flag && base.projectile.ai[0] == 0f)
			{
				Vector2 value2 = value - base.projectile.Center;
				if (value2.Length() > 200f)
				{
					value2.Normalize();
					base.projectile.velocity = (base.projectile.velocity * 20f + value2 * 6f) / 21f;
				}
				else
				{
					base.projectile.velocity *= (float)Math.Pow(0.97, 2.0);
				}
			}
			else
			{
				if (!Collision.CanHitLine(base.projectile.Center, 1, 1, player.Center, 1, 1))
				{
					base.projectile.ai[0] = 1f;
				}
				float num4 = 6f;
				if (base.projectile.ai[0] == 1f)
				{
					num4 = 15f;
				}
				Vector2 center = base.projectile.Center;
				Vector2 vector = player.Center - center;
				base.projectile.ai[1] = 3600f;
				base.projectile.netUpdate = true;
				int num5 = 1;
				for (int k = 0; k < base.projectile.whoAmI; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == base.projectile.owner && Main.projectile[k].type == base.projectile.type)
					{
						num5++;
					}
				}
				vector.X -= (float)((10 + num5 * 40) * player.direction);
				vector.Y -= 70f;
				float num6 = vector.Length();
				if (num6 > 200f && num4 < 9f)
				{
					num4 = 9f;
				}
				if (num6 < 100f && base.projectile.ai[0] == 1f && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
				{
					base.projectile.ai[0] = 0f;
					base.projectile.netUpdate = true;
				}
				if (num6 > 2000f)
				{
					base.projectile.Center = player.Center;
				}
				if (num6 > 48f)
				{
					vector.Normalize();
					vector *= num4;
					float num7 = 10f;
					base.projectile.velocity = (base.projectile.velocity * num7 + vector) / (num7 + 1f);
				}
				else
				{
					base.projectile.direction = Main.player[base.projectile.owner].direction;
					base.projectile.velocity *= (float)Math.Pow(0.9, 2.0);
				}
			}
			base.projectile.rotation = base.projectile.velocity.X * 0.05f;
			if (base.projectile.velocity.X > 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = -1);
			}
			else if (base.projectile.velocity.X < 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = 1);
			}
			if (base.projectile.ai[1] > 0f)
			{
				base.projectile.ai[1] += 1f;
			}
			if (base.projectile.ai[1] > 140f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[0] == 0f && flag)
			{
				if ((value - base.projectile.Center).X > 0f)
				{
					base.projectile.spriteDirection = (base.projectile.direction = -1);
				}
				else if ((value - base.projectile.Center).X < 0f)
				{
					base.projectile.spriteDirection = (base.projectile.direction = 1);
				}
				if (base.projectile.ai[1] == 0f)
				{
					base.projectile.ai[1] = 1f;
					if (Main.myPlayer == base.projectile.owner)
					{
						Vector2 vector2 = value - base.projectile.Center;
						if (vector2 == Vector2.Zero)
						{
							vector2 = new Vector2(0f, 1f);
						}
						vector2.Normalize();
						vector2 *= 9f;
						int num8 = Terraria.Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector2.X, vector2.Y, base.mod.ProjectileType("WitherBolt1"), 19, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
						Main.projectile[num8].timeLeft = 300;
						Main.projectile[num8].netUpdate = true;
						base.projectile.netUpdate = true;
					}
				}
			}
			if (base.projectile.ai[0] == 0f)
			{
				if (Main.rand.Next(5) == 0)
				{
					int num9 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height / 2, 187, 0f, 0f, 0, default(Color), 1f);
					Dust expr_8EC_cp_0 = Main.dust[num9];
					expr_8EC_cp_0.velocity.Y = expr_8EC_cp_0.velocity.Y - 1.2f;
				}
			}
			else if (Main.rand.Next(3) == 0)
			{
				Vector2 velocity = base.projectile.velocity;
				if (velocity != Vector2.Zero)
				{
					velocity.Normalize();
				}
				int num10 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 187, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num10].velocity -= 1.2f * velocity;
			}
			Lighting.AddLight((int)(base.projectile.Center.X / 16f), (int)(base.projectile.Center.Y / 16f), 0.2f, 0.2f, 0.9f);
		}

        public override void SelectFrame()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter >= 10)
			{
				base.projectile.frameCounter = 0;
				base.projectile.frame = (base.projectile.frame + 1) % Main.projFrames[base.projectile.type];
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)(texture2D.Height / Main.projFrames[base.projectile.type]) * 0.5f);
			SpriteEffects effects = (base.projectile.direction == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 value = new Vector2(base.projectile.Center.X - 4f, base.projectile.Center.Y - 8f);
			Main.spriteBatch.Draw(texture2D, value - Main.screenPosition, new Rectangle?(Utils.Frame(texture2D, 1, Main.projFrames[base.projectile.type], 0, base.projectile.frame)), lightColor, base.projectile.rotation, origin, base.projectile.scale, effects, 0f);
			return false;
		}
	}
}
