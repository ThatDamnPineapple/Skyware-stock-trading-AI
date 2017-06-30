using System;
using System.Collections.Generic;
using Terraria;

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
            if (InvasionHandler.invasions == null)
            {
                InvasionHandler.invasions = new Dictionary<int, InvasionInfo>();
            }
            key = 1;
            while (InvasionHandler.invasions.ContainsKey(key))
            {
                key++;
            }
            InvasionHandler.invasions.Add(key, info);
        }

        public static InvasionInfo GetInvasionInfo(int key)
        {
            InvasionInfo result;
            if (InvasionHandler.invasions == null)
            {
                result = null;
            }
            else if (InvasionHandler.invasions.ContainsKey(key))
            {
                result = InvasionHandler.invasions[key];
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static InvasionInfo GetInvasionInfo(string name)
        {
            InvasionInfo result;
            if (InvasionHandler.invasions == null)
            {
                result = null;
            }
            else
            {
                for (int i = 0; i < InvasionHandler.invasions.Count; i++)
                {
                    if (InvasionHandler.invasions[i].name == name)
                    {
                        result = InvasionHandler.invasions[i];
                        return result;
                    }
                }
                result = null;
            }
            return result;
        }

        public static void StartCustomInvasion(int type)
        {
            if (InvasionHandler.invasions != null)
            {
                if (Main.invasionType != 0 && Main.invasionSize == 0)
                {
                    Main.invasionType = 0;
                }
                if (Main.invasionType == 0 && InvasionWorld.invasionType == 0)
                {
                    InvasionInfo info = InvasionHandler.GetInvasionInfo(type);
                    info.invasionSizeModifier();
                    if (InvasionWorld.invasionSize > 0)
                    {
                        InvasionWorld.invasionType = type;
                        InvasionWorld.invasionSizeStart = InvasionWorld.invasionSize;
                        InvasionWorld.invasionProgress = 0;
                        InvasionWorld.invasionProgressMax = Main.invasionSizeStart;
                        InvasionWorld.invasionX = info.invasionXPos;
                    }
                }
            }
            NetMessage.SendData(7);
        }

        public static void ReportInvasionProgress(int progress, int progressMax, int progressWave)
        {
            InvasionWorld.invasionProgress = progress;
            InvasionWorld.invasionProgressMax = progressMax;
            InvasionHandler.invasionProgressDisplayLeft = 160;
            if (progressMax - progress <= 0)
            {
                if (Main.netMode == 0)
                {
                    Main.NewText(InvasionHandler.currentInvasion.endMessage, 175, 75, 255, false);
                }
                else if (Main.netMode == 2)
                {
                    NetMessage.SendData(25, -1, -1, null, 255, 60f, 255f, 255f, 0, 0, 0);
                }
                InvasionHandler.currentInvasion = null;
                InvasionWorld.invasionSize = 0;
                InvasionWorld.invasionType = 0;
            }
            NetMessage.SendData(7);
        }

        public static void Reset()
        {
            InvasionHandler.invasions = new Dictionary<int, InvasionInfo>();
            InvasionHandler.currentInvasion = null;
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
