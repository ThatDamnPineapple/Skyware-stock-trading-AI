using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Scarabeus
{
    public class ScarabDust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scarab Dust");
        }
        public override void SetDefaults()
        {
            projectile.name = "Scarab Dust";
            projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 4;
			projectile.alpha = 255;
			projectile.timeLeft = 60;
        }

        public override bool PreAI()
        {
        	int randomDustType = Main.rand.Next(3);
        	if (randomDustType == 0)
        	{
        		randomDustType = 85;
        	}
        	else if (randomDustType == 1)
        	{
        		randomDustType = 36;
        	}
        	else
        	{
        		randomDustType = 32;
        	}
        	for (int dust = 0; dust < 3; dust++)
        	{
        		Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, randomDustType, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
        	}
            return false;
        }
        
        public override void Kill(int timeLeft)
        {
			if (projectile.owner == Main.myPlayer)
			{
				int num814 = 4;
				int num815 = (int)(projectile.position.X / 16f - (float)num814);
				int num816 = (int)(projectile.position.X / 16f + (float)num814);
				int num817 = (int)(projectile.position.Y / 16f - (float)num814);
				int num818 = (int)(projectile.position.Y / 16f + (float)num814);
				if (num815 < 0)
				{
					num815 = 0;
				}
				if (num816 > Main.maxTilesX)
				{
					num816 = Main.maxTilesX;
				}
				if (num817 < 0)
				{
					num817 = 0;
				}
				if (num818 > Main.maxTilesY)
				{
					num818 = Main.maxTilesY;
				}
				for (int num824 = num815; num824 <= num816; num824++)
				{
					for (int num825 = num817; num825 <= num818; num825++)
					{
						float num826 = Math.Abs((float)num824 - projectile.position.X / 16f);
						float num827 = Math.Abs((float)num825 - projectile.position.Y / 16f);
						double num828 = Math.Sqrt((double)(num826 * num826 + num827 * num827));
						if (num828 < (double)num814)
						{
							if (Main.tile[num824, num825] != null && Main.tile[num824, num825].active() && Main.tile[num824, num825].type == 19) //19 is platforms
							{
								WorldGen.KillTile(num824, num825, false, false, false);
								if (!Main.tile[num824, num825].active() && Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, null, 0, (float)num824, (float)num825, 0f, 0, 0, 0);
								}
							}
						}
					}
				}
				if (Main.netMode != 0)
				{
					NetMessage.SendData(29, -1, -1, null, projectile.identity, (float)projectile.owner, 0f, 0f, 0, 0, 0);
				}
				if (!projectile.noDropItem)
				{
					int num831 = -1;
					if (Main.netMode == 1 && num831 >= 0)
					{
						NetMessage.SendData(21, -1, -1, null, num831, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			projectile.active = false;	
        }
    }
}