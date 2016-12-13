using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace SpiritMod.Items.Weapon.Swung
{
    public class RageBlazeDecapitator : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rage Blaze Decapitator";
            item.damage = 68;
            item.melee = true;
            item.width = 31;
            item.height = 25;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 10;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = true;
            item.crit = 8;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            {

                MyPlayer gp = (MyPlayer)Main.player[Main.myPlayer].GetModPlayer(mod, "MyPlayer");
                {
                    gp.HitNumber++;
                    CombatText.NewText(new Rectangle((int)gp.player.position.X, (int)gp.player.position.Y - 300, gp.player.width, gp.player.height), new Color(29, 240, 255, 100),
                    "Hit Number: " + gp.HitNumber);
                }
            }
        }

        public override bool UseItem(Player p)
        {
            Player player = Main.player[item.owner];

            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            {
                if (modPlayer.HitNumber >= 5)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        float rotation = (float)(Main.rand.Next(0, 361) * (Math.PI / 180));
                        Vector2 velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                        int proj = Projectile.NewProjectile(player.Center.X, player.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("GraniteShard"), item.damage, item.owner, 0, 0f);
                        Main.projectile[proj].friendly = true;
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].velocity *= 4f;
                        modPlayer.HitNumber = 0;
                    }
                }
                return true;
            }
        }
    }
}