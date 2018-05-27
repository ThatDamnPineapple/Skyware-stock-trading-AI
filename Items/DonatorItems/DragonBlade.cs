using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using SpiritMod.NPCs;
using SpiritMod.Mounts;
namespace SpiritMod.Items.DonatorItems
{
	public class DragonBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Blade");
			Tooltip.SetDefault("Right click to dash forward\n~Donator Item~");
		}
			int charge = 10;
		//	int infernaldash = 0;
		public override void SetDefaults()
		{
			item.damage = 52;
			item.useTime = 18;
			item.useAnimation = 18;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 25700;
			item.rare = 5;
			item.crit = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 75);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
		}

		public override bool UseItem(Player player)
        {
			charge++;
            if (player.altFunctionUse == 2)
            {
				if (charge >= 10)
				{
					item.useTime = 60;
			item.useAnimation = 60;
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
								float knockback = 12f;
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
										NetMessage.SendData(28, -1, -1, null, i, damage, knockback, (float)hitDirection, 0, 0, 0);
									}
								}
								player.dashDelay = 30;
								player.velocity.X = -(float)hitDirection * 1f;
								player.velocity.Y = -4f;
								player.immune = true;
								player.immuneTime = 2;
							//	this.infernalHit = i;
							}
							}
						}
						int num21 = 0;
					bool flag2 = false;
					if (player.dashTime > 0)
						player.dashTime--;
					if (player.dashTime < 0)
						player.dashTime++;
					if (player.velocity.X > 0)
					{
						//if (player.dashTime > 0)
						//{
							num21 = 1;
							flag2 = true;
							//player.dashTime = 0;
						//}
						
					}
					else if (player.velocity.X < 0)
					{
						//if (player.dashTime < 0)
						//{
							num21 = -1;
							flag2 = true;
						//	player.dashTime = 0;
						//}
						
					}
					if (flag2)
					{
						int dust2 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
						Main.dust[dust2].scale *= 2f;
						int dust = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
						Main.dust[dust].scale *= 2f;
						player.velocity.X = 15.5f * (float)num21;
						Point point3 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point4 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						//player.dashDelay = -1;
						//this.infernalDash = 15;
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
				else
				{
					return false;
				}
				charge = 0;
			}
			else
			{
				item.useTime = 18;
			item.useAnimation = 18;
			}
			return true;
		}
		 public override bool AltFunctionUse(Player player)
        {
            return true;
        }
		
	}
}