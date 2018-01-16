using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using System.IO;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class AsteroidSummon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Asteroid Summon");
		}


      public override void SetDefaults()
		{
			item.value = 10000;
			item.width = 22;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 8;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.UseSound = SoundID.Item81;
			item.consumable = true;
		}
        
		public static void Asteroids(ushort type)
		{
			int Bx = Main.rand.Next(1700, Main.maxTilesX - 1700);
			Main.NewText("Strange objects fill the sky", 100, 220, 100);
			for (int k = 0; k < 200; k++)
			{
			//	Main.NewText("asteroids...begin!", 100, 220, 100);
			int x = Bx + Main.rand.Next(-1000, 1000);
			int y = Main.rand.Next(35, 150);
			int size = Main.rand.Next(5, 18);
			Asteroid(x, y, size, type);
			}
		}
		
		public static void Asteroid(int X, int Y, int size, ushort type) 
		{
			//Main.NewText("asteroid", 100, 220, 100);
		WorldMethods.TileRunner(X, Y, (double)size * 2f, 1, type, true, 0f, 0f, true, true);
            
            for (int rotation2 = 0; rotation2 < 350; rotation2++)
            {
                int DistX = (int)(0 - (Math.Sin(rotation2) * size));
                int DistY = (int)(0 - (Math.Cos(rotation2) * size));
                WorldMethods.TileRunner(X + DistX, Y + DistY, (double)size * 0.75f, 1, type, true, 0f, 0f, true, true);
            }
		}
        public override bool UseItem(Player player)
		{
			
				Asteroids((ushort)mod.TileType("Asteroid"));		
			return true;
		}
    }
}
