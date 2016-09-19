using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod
{
    public static class InvasionHandler
    {
        public const int customInvasionTypeStart = 5;
        private static Dictionary<int, InvasionInfo> invasions;

        public static InvasionInfo currentInvasion;

        public static float invasionProgressAlpha;
        public static int invasionProgressDisplayLeft;

        public static void AddInvasion(out int key, InvasionInfo info)
        {
            if (invasions == null) invasions = new Dictionary<int, InvasionInfo>();

            key = customInvasionTypeStart;
            while (invasions.ContainsKey(key))
            {
                key++;
            }
            invasions.Add(key, info);
        }
        public static InvasionInfo GetInvasionInfo(int key)
        {
            if (invasions == null) return null;

            if (InvasionHandler.invasions.ContainsKey(key))
            {
                return invasions[key];
            }

            return null;
        }
        public static InvasionInfo GetInvasionInfo(string name)
        {
            if (invasions == null) return null;

            for (int i = 0; i < invasions.Count; ++i)
            {
                if (invasions[i].name == name)
                {
                    return invasions[i];
                }
            }
            return null;
        }

        public static void StartCustomInvasion(int type)
        {
            if (invasions == null) return;

            // If there is an invasion going on, but the invasion has basically already ended (invasionSize = 0).
            if (Main.invasionType != 0 && Main.invasionSize == 0)
            {
                Main.invasionType = 0;
            }

            if (Main.invasionType == 0)
            {
                InvasionInfo info = GetInvasionInfo(type);
                info.invasionSizeModifier();

                if (Main.invasionSize > 0)
                {
                    Main.invasionType = type;

                    Main.invasionSizeStart = Main.invasionSize;
                    Main.invasionProgress = 0;
                    Main.invasionProgressWave = 0;
                    Main.invasionProgressMax = Main.invasionSizeStart;
                    Main.invasionWarn = 3600;
                    Main.invasionX = info.invasionXPos;
                }
            }
        }

        public static void ReportInvasionProgress(int progress, int progressMax, int progressWave)
        {
            Main.invasionProgress = progress;
            Main.invasionProgressMax = progressMax;
            Main.invasionProgressWave = progressWave;
            InvasionHandler.invasionProgressDisplayLeft = 160;

            // Invasion has ended
            if (progressMax - progress <= 0)
            {
                if (Main.netMode == 0)
                    Main.NewText(currentInvasion.endMessage, 175, 75, 255, false);
                else if (Main.netMode == 2)
                    NetMessage.SendData(25, -1, -1, currentInvasion.endMessage, 255, 175f, 75f, 255f, 0, 0, 0);

                currentInvasion = null;
                Main.invasionSize = 0;
                Main.invasionType = 0;
            }
        }

        public static void Reset()
        {
            invasions = null;
            currentInvasion = null;
        }
    }

    public delegate bool InvasionSizeModifier();
    public class InvasionInfo
    {
        public string name = "";
        public string beginMessage = "";
        public string endMessage = "";
        public int invasionXPos;

        public Texture2D invasionIcon;

        public InvasionSizeModifier invasionSizeModifier;

        public InvasionInfo(string name, string beginMessage, string endMessage, InvasionSizeModifier invasionSizeModifier,
            Texture2D invasionIcon)
        {
            this.name = name;
            this.beginMessage = beginMessage;
            this.endMessage = endMessage;
            this.invasionSizeModifier = invasionSizeModifier;

            this.invasionIcon = invasionIcon;
        }
    }
}
