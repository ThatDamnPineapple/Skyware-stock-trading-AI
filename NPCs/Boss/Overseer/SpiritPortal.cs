using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Overseer
{
    public class SpiritPortal : ModProjectile
    {
        bool start = true;
        // USE THIS DUST: 261
        public override void SetDefaults()
        {
            projectile.name = "Spirit Portal";
            projectile.width = projectile.height = 100;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;

            projectile.penetrate = -1;

            projectile.timeLeft = 500;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
        }
        public override bool PreAI()
        {
            if (start)
            {
                for (int num621 = 0; num621 < 55; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, 0f, 0f, 206, default(Color), 2f);

                }
                
                projectile.ai[1] = projectile.ai[0];
                start = false;
            }
            //projectile.rotation = projectile.rotation + 3f;
            //Making player variable "p" set as the projectile's owner
            Player player = Main.player[Main.myPlayer]; // CHANGE TO OVERSEER'S TARGET IN FULL VERSION!!!!!
            
            //Factors for calculations
            double deg = (double)projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 100; //Distance away from the player

            /*Position the projectile based on where the player is, the Sin/Cos of the angle times the /
    		/distance for the desired distance away from the player minus the projectile's width   /
    		/and height divided by two so the center of the projectile is at the right place.     */
            projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 2f;

            return false;
        }

       /* public override void SendExtraAI(System.IO.BinaryWriter writer)
        {
            writer.Write(this.target);
        }
        public override void ReceiveExtraAI(System.IO.BinaryReader reader)
        {
            this.target = reader.Read();
        }*/
    }
}
