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
        public const int customInvasionTypeStart = 1;
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

            if (Main.invasionType == 0 && InvasionWorld.invasionType == 0)
            {
                InvasionInfo info = GetInvasionInfo(type);
                info.invasionSizeModifier();

                if (InvasionWorld.invasionSize > 0)
                {
                    InvasionWorld.invasionType = type;

                    InvasionWorld.invasionSizeStart = InvasionWorld.invasionSize;
                    InvasionWorld.invasionProgress = 0;
                    //InvasionWorld.invasionProgressWave = 0;
                    InvasionWorld.invasionProgressMax = Main.invasionSizeStart;
                    InvasionWorld.invasionX = info.invasionXPos;

                }
            }
        }

        public static void ReportInvasionProgress(int progress, int progressMax, int progressWave)
        {
            InvasionWorld.invasionProgress = progress;
            InvasionWorld.invasionProgressMax = progressMax;
            //Main.invasionProgressWave = progressWave;
            InvasionHandler.invasionProgressDisplayLeft = 160;

            // Invasion has ended
            if (progressMax - progress <= 0)
            {
                if (Main.netMode == 0)
                    Main.NewText(currentInvasion.endMessage, 175, 75, 255, false);
                else if (Main.netMode == 2)
                    NetMessage.SendData(25, -1, -1, currentInvasion.endMessage, 255, 60f, 255f, 255f, 0, 0, 0);

                currentInvasion = null;
                InvasionWorld.invasionSize = 0;
                InvasionWorld.invasionType = 0;
            }
        }

        public static void Reset()
        {
            invasions = new Dictionary<int, InvasionInfo>();
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


        public InvasionSizeModifier invasionSizeModifier;

        public InvasionInfo(string name, string beginMessage, string endMessage, InvasionSizeModifier invasionSizeModifier)
        {
            this.name = name;
            this.beginMessage = beginMessage;
            this.endMessage = endMessage;
            this.invasionSizeModifier = invasionSizeModifier;

        }
    }
}
