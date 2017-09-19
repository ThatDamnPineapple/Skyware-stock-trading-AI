using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
	public static class SpawnExtras
	{
		//Mapping every field in player.zone1/2
		public const int SPAWN_DUNGEON = 1;
		public const int SPAWN_CORRUPT = 1 << 1;
		public const int SPAWN_HALLOW = 1 << 2;
		public const int SPAWN_METEOR = 1 << 3;
		public const int SPAWN_JUNGLE = 1 << 4;
		public const int SPAWN_SNOW = 1 << 5;
		public const int SPAWN_CRIMSON = 1 << 6;
		public const int SPAWN_WATERCANDLE = 1 << 7;
		public const int SPAWN_PEACECANDLE = 1 << 8;
		public const int SPAWN_SOLAR = 1 << 9;
		public const int SPAWN_VORTEX = 1 << 10;
		public const int SPAWN_NEBULA = 1 << 11;
		public const int SPAWN_STARDUST = 1 << 12;
		public const int SPAWN_DESERT = 1 << 13;
		public const int SPAWN_MUSHROOM = 1 << 14;
		public const int SPAWN_DEEPDESERT = 1 << 15;
		//End of player.zone mapping

		//This exists because it is part of NPCSpawnInfo
		// It is true, if the player stands in front of desert background
		public const int SPAWN_DESERTCAVE = 1 << 16; //info.desertCave
		public const int SPAWN_GRANITE = 1 << 17; //info.granite
		public const int SPAWN_MARBLE = 1 << 18; //info.marble
		public const int SPAWN_LIZAHRD = 1 << 19; //info.lihzahrd
		public const int SPAWN_SPIDERCAVE = 1 << 20;//info.spiderCave

		//This field is true when sky mobs should spawn,
		// it's not the same as LayerSpace below!
		public const int SPAWN_SKY = 1 << 21; //info.sky
		public const int SPAWN_WATER = 1 << 22; //info.water

		//This is true, when the player is standing in front of a non-natural wall.
		public const int SPAWN_SAFEWALL = 1 << 23;//info.playerSafe
		public const int SPAWN_TOWN = 1 << 24; //info.playerInTown
		public const int SPAWN_INVASION = 1 << 25; //info.invasion

		public const int SPAWN_TOWERS = SPAWN_SOLAR | SPAWN_VORTEX | SPAWN_NEBULA | SPAWN_STARDUST;

		//All flags, which do not usually hinder spawning.
		public const int SPAWN_IGNORE = SPAWN_CORRUPT | SPAWN_CRIMSON | SPAWN_HALLOW | SPAWN_JUNGLE | SPAWN_SNOW | SPAWN_DESERT | SPAWN_MUSHROOM | SPAWN_DEEPDESERT | SPAWN_WATERCANDLE | SPAWN_PEACECANDLE
			| SPAWN_DESERTCAVE | SPAWN_GRANITE | SPAWN_MARBLE | SPAWN_SPIDERCAVE | SPAWN_WATER | SPAWN_SAFEWALL | SPAWN_TOWN;

		//COmpare these with Main.invasionType to determine the invasion type.
		public const int INVASION_NONE = 0;
		public const int INVASION_GOBLINS = 1;
		public const int INVASION_FROST = 2;
		public const int INVASION_PIRATES = 3;
		public const int INVASION_MARTIANS = 4;

		public static bool SupressSpawns(NPCSpawnInfo info, int ignoreFlags = SPAWN_IGNORE)
		{
			return (info.player.zone1 & ~ignoreFlags) != 0 || ((int)info.player.zone2 << 8 & ~ignoreFlags) != 0 ||
				info.desertCave && (ignoreFlags & SPAWN_DESERTCAVE) == 0 || info.granite && (ignoreFlags & SPAWN_GRANITE) == 0 ||
				info.marble && (ignoreFlags & SPAWN_MARBLE) == 0 || info.lihzahrd && (ignoreFlags & SPAWN_LIZAHRD) == 0 ||
				info.spiderCave && (ignoreFlags & SPAWN_SPIDERCAVE) == 0 || info.sky && (ignoreFlags & SPAWN_SKY) == 0 ||
				info.water && (ignoreFlags & SPAWN_WATER) == 0 || info.playerSafe && (ignoreFlags & SPAWN_SAFEWALL) == 0 ||
				info.playerInTown && (ignoreFlags & SPAWN_TOWN) == 0 || info.invasion && (ignoreFlags & SPAWN_INVASION) == 0;
		}


		public static float LayerSpaceEnd
		{
			get
			{
				return (float)(3.2 * Main.worldSurface + (Main.maxTilesX > 7400 ? 640f : 160f) + 1060d); //1040f
			}
		}
		public static float LayerSurfaceStart
		{
			get
			{
				return LayerSpaceEnd;
			}
		}
		public static float LayerSurfaceEnd
		{
			get
			{
				return (float)(Main.worldSurface * 16f);
			}
		}
		public static float LayerDirtStart
		{
			get
			{
				return LayerSurfaceEnd;
			}
		}
		public static float LayerDirtEnd
		{
			get
			{
				return (float)(Main.rockLayer * 16f + 600f);
			}
		}
		public static float LayerCavernStart
		{
			get
			{
				return LayerDirtEnd;
			}
		}
		public static float LayerCavernEnd
		{
			get
			{
				return (float)(Main.bottomWorld - 4800f - (Main.maxTilesX>7400 ? -24f : Main.maxTilesX > 5300 ? 40f : 8f));
			}
		}
		public static float LayerPreUnderworldStart
		{
			get
			{
				return LayerCavernEnd;
			}
		}
		public static float LayerPreUnderworldEnd
		{
			get
			{
				return (float)(Main.bottomWorld - 3152f - (Main.maxTilesX > 7400 ? -24f : Main.maxTilesX > 5300 ? 40f : 8f));
			}
		}
		public static float LayerUnderworldStart
		{
			get
			{
				return LayerPreUnderworldEnd;
			}
		}
		public static float LayerLavaStart //I have no idea if this is correct
		{
			get
			{
				return (float)(Main.bottomWorld - Main.rockLayer * 16f);
			}
		}


		public static bool ZoneOcean(Player player)
		{
			int tileX = (int)((player.position.X + (player.width >> 1)) * 0.0625f);
			int tileY = (int)((player.position.Y + player.height) * 0.0625f);

			return (tileX < 380 || tileX > Main.maxTilesX - 380) && tileY < Main.rockLayer;

			//if (tileY < Main.worldSurface && !inSky && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneDesert && !player.ZoneGlowshroom)
			//{
			//	//In the Forest
			//	if (!player.ZoneMeteor && !player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust)
			//	{
			//		//Strictly no other biomes
			//	}
			//}
		}

		public static bool ZoneUnderworld(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y > LayerUnderworldStart;
		}

		public static bool ZonePreUnderworld(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y > LayerPreUnderworldStart && Y <= LayerPreUnderworldEnd;
		}

		public static bool ZoneCavern(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y > LayerCavernStart && Y <= LayerCavernEnd;
		}

		public static bool ZoneDirt(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y > LayerDirtStart && Y <= LayerDirtEnd;
		}

		public static bool ZoneSurface(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y > LayerSurfaceStart && Y <= LayerSurfaceEnd;
		}

		public static bool ZoneSpace(Player player)
		{
			float Y = player.position.Y + player.height;
			return Y <= LayerSpaceEnd;
		}

		public static bool ZonePure(Player player)
		{
			return !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneGlowshroom;
		}

		//Best ore
		//Lang.mapLegend.FromType(Main.player[Main.myPlayer].bestOre)


	}
}
