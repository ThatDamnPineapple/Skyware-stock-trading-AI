using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RunicHood : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Runic Hood";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increased Magic Damage and Movement Speed.";
            item.value = 10000;
            item.rare = 8;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("RunicPlate") && legs.type == mod.ItemType("RunicGreaves");  
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Setbonus Dont Works Currently!";
			PlayerHook modPlayer = player.GetModPlayer< PlayerHook>(mod);
			modPlayer.runicSet = true;
			SpawnRunes(player);
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage = 1.12f;
            player.moveSpeed += 1.05f;
        }

		private void SpawnRunes(Player player)
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
								} else
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