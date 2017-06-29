using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;

namespace SpiritMod.Items.Consumable
{
    public class SpiritSpawner : ModItem
    {
		 private int WillGenn = 0;
		 private int Meme;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Spawner");
			Tooltip.SetDefault("Spawns the spirit biome \nCheat item \nDo not use if your world already has the Spirit Biome");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            #region SpiritBiome
                    Main.NewText("The Spirits spread through the Land...", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    Random rand = new Random();
                    int XTILE;
                    if (Terraria.Main.dungeonX > Main.maxTilesX / 2) //rightside dungeon
                    {
                        XTILE = WorldGen.genRand.Next(Main.maxTilesX / 2, Main.maxTilesX - 500);
                    }
                    else //leftside dungeon
                    {
                        XTILE = WorldGen.genRand.Next(75, Main.maxTilesX / 2);
                    }
                    int xAxis = XTILE;
                    int xAxisMid = xAxis + 70;
                    int xAxisEdge = xAxis + 380;
                    int yAxis = 0;
                    for (int y = 0; y < Main.maxTilesY; y++)
                    {
                        yAxis++;
                        xAxis = XTILE;

                        for (int i = 0; i < 450; i++)
                        {
                            xAxis++;

                            
                            if (Main.tile[xAxis, yAxis] != null)
                            {
                                if (Main.tile[xAxis, yAxis].active())
                                {
                                    int[] TileArray = { 0 };
                                    if (TileArray.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (Main.rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {
                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 10)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritDirt");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 10)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritDirt");
                                            }
                                        }
                                    }

                                    int[] TileArray1 = { 2, 23, 109, 199 };
                                    if (TileArray1.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {
                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
                                            }
                                        }
                                    }

                                    int[] TileArray2 = { 1, 25, 117, 203 };
                                    if (TileArray2.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
                                            }
                                        }
                                    }

                                    int[] TileArray3 = { 53, 116, 112, 234 };
                                    if (TileArray3.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("Spiritsand");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("Spiritsand");
                                            }
                                        }
                                    }

                                    int[] TileArray4 = { 161, 163, 200, 164 };
                                    if (TileArray4.Contains(Main.tile[xAxis, yAxis].type))
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
                                                WillGenn = 0;
                                                if (xAxis < xAxisMid - 1)
                                                {

                                                    Meme = xAxisMid - xAxis;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (xAxis > xAxisEdge + 1)
                                                {
                                                    Meme = xAxis - xAxisEdge;
                                                    WillGenn = Main.rand.Next(Meme);
                                                }
                                                if (WillGenn < 18)
                                                {
                                                    Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WillGenn = 0;
                                            if (xAxis < xAxisMid - 1)
                                            {
                                                Meme = xAxisMid - xAxis;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (xAxis > xAxisEdge + 1)
                                            {
                                                Meme = xAxis - xAxisEdge;
                                                WillGenn = Main.rand.Next(Meme);
                                            }
                                            if (WillGenn < 18)
                                            {
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
                                            }
                                        }
                                    }
                                }
                                if (Main.tile[xAxis, yAxis].type == mod.TileType("SpiritStone") && yAxis > WorldGen.rockLayer + 100 && Main.rand.Next(1500) == 6)
                                {
                                    WorldGen.TileRunner(xAxis, yAxis, (double)WorldGen.genRand.Next(5, 7), 1, mod.TileType("SpiritOreTile"), false, 0f, 0f, true, true);
                                }
                            }
                            
                        }
                    }
					#endregion
            return true;
        }

        }
}
