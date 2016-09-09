using Terraria;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class IlluminantMaster : ModNPC
    {
		private float XSpeed;
		private float YSpeed;
        private float XSpeedFae;
        private float YSpeedFae;
        public override void SetDefaults()
        {
            npc.name = "Illuminant Master";
            npc.displayName = "Illuminant Master";
            npc.width = 130;
            npc.height = 154;
            npc.damage = 32;
			npc.noTileCollide = true;
            npc.defense = 34;
			npc.boss = true;
            npc.lifeMax = 22000;
            npc.soundHit = 1;
            npc.soundKilled = 1;
			npc.noGravity = true;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 7;
     
        }
		public override void AI()
        {
		if (npc.life < 11000)
		{ 
			float Xdis = Main.player[Main.myPlayer].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
			float Ydis = Main.player[Main.myPlayer].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
			float Angle = (float)Math.Atan(Xdis / Ydis);
			float TrijectoryX = (float)(Math.Sin(Angle));
			float TrijectoryY = (float)(Math.Cos(Angle));
			npc.ai[0]++;
			if(npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X < npc.Center.X) // X
			{
				XSpeed = 0 - TrijectoryX;
				YSpeed = 0 - TrijectoryY;
				//Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
			}
			
			if(npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
			{
				XSpeed = 0 - TrijectoryX;
				YSpeed = 0 - TrijectoryY;
				//Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
			}
			if(npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
			{
				XSpeed = TrijectoryX;
				YSpeed = TrijectoryY;
				//Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
			}
                if (npc.ai[0] % 250 >= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X < npc.Center.X) // X
                {
                    XSpeedFae = 0 - TrijectoryX;
                    YSpeedFae = 0 - TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }

                if (npc.ai[0] % 250 >= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
                {
                    XSpeedFae = 0 - TrijectoryX;
                    YSpeedFae = 0 - TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 >= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
                {
                    XSpeedFae = TrijectoryX;
                    YSpeedFae = TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 >= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X <= npc.Center.X) // X
                {
                    XSpeedFae = TrijectoryX;
                    YSpeedFae = TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X <= npc.Center.X) // X
			{
				XSpeed = TrijectoryX;
				YSpeed = TrijectoryY;
				//Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
			}
			if(npc.ai[0] % 250 >= 76) // X
			{
				npc.velocity.X = XSpeed * 9;
				npc.velocity.Y = YSpeed * 9;
				//Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
			}
			if(Main.rand.Next(100) == 1) // X
			{
					Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (XSpeedFae * 15), YSpeedFae * 15, mod.ProjectileType("FaeStar"), 22, 0f, Main.myPlayer);
				//Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
			}
			if(npc.ai[0] % 250 >= 76 && npc.ai[0] % 35 == 0) // X
			{
					Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 50, 0.1f, 8f, mod.ProjectileType("Starstrike"), 25, 0f, Main.myPlayer);
				//Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
			}
			if(npc.ai[0] % 250 == 0) // Y
			{
				npc.position.X = (Main.player[Main.myPlayer].position.X - 300) + Main.rand.Next(600);
				npc.position.Y = (Main.player[Main.myPlayer].position.Y - 300) + Main.rand.Next(600);
				//Main.NewText("Teleported", 0, 0, 0, true);
			}
			if(npc.ai[0] % 250 < 75) // Z
			{
				npc.velocity.X = TrijectoryX;
				npc.velocity.Y = TrijectoryX;
			}
			if (npc.ai[0]%8==0)
            {
                npc.frame.Y = (int)(npc.height * npc.frameCounter);
                npc.frameCounter = (npc.frameCounter+1) % 5;
            }
		}
		if (npc.life >= 11000)
		{
                float Xdis = Main.player[Main.myPlayer].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
                float Ydis = Main.player[Main.myPlayer].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
                float Angle = (float)Math.Atan(Xdis / Ydis);
                float TrijectoryX = (float)(Math.Sin(Angle));
                float TrijectoryY = (float)(Math.Cos(Angle));
                npc.ai[0]++;
                if (npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X < npc.Center.X) // X
                {
                    XSpeed = 0 - TrijectoryX;
                    YSpeed = 0 - TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }

                if (npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y < npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
                {
                    XSpeed = 0 - TrijectoryX;
                    YSpeed = 0 - TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X > npc.Center.X) // X
                {
                    XSpeed = TrijectoryX;
                    YSpeed = TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 <= 75 && Main.player[Main.myPlayer].Center.Y >= npc.Center.Y && Main.player[Main.myPlayer].Center.X <= npc.Center.X) // X
                {
                    XSpeed = TrijectoryX;
                    YSpeed = TrijectoryY;
                    //Main.NewText("" + XSpeed + "Is what it will go", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 >= 76) // X
                {
                    npc.velocity.X = XSpeed * 8;
                    npc.velocity.Y = YSpeed * 8;
                    //Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 == 30 && Main.rand.Next(2) == 1) // X
                {
                    Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (XSpeed * 3), YSpeed * 3, mod.ProjectileType("Spark"), 22, 0f, Main.myPlayer);
                    Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (XSpeed * 3) * 0.85f, (YSpeed * 3) * 1.25f, mod.ProjectileType("Spark"), 22, 0f, Main.myPlayer);
                    Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (XSpeed * 3) * 1.15f, (YSpeed * 3) * 0.85f, mod.ProjectileType("Spark"), 22, 0f, Main.myPlayer);
                    //Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 >= 76 && npc.ai[0] % 35 == 0) // X
                {
                    Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 50, 0.1f, 8f, mod.ProjectileType("Starstrike"), 25, 0f, Main.myPlayer);
                    //Main.NewText("" + XSpeed + "Is what it is moving at", 0, 0, 0, true);
                }
                if (npc.ai[0] % 250 < 75) // Z
                {
                    npc.velocity.X = TrijectoryX;
                    npc.velocity.Y = TrijectoryX;
                }
                if (npc.ai[0] % 8 == 0)
                {
                    npc.frame.Y = (int)(npc.height * npc.frameCounter);
                    npc.frameCounter = (npc.frameCounter + 1) % 5;
                }
            }
		}
    }
}