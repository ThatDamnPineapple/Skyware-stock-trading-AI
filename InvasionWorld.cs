using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpiritMod
{
    public class InvasionWorld : ModWorld
    {
        public static int invasionType = 0;

        public static int invasionSizeStart = 0;

        public static int invasionSize = 0;

        public static int invasionX = 0;

        public static int invasionProgress = 0;

        public static int invasionProgressMax = 0;

        private bool loaded = false;

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte(InvasionWorld.invasionProgress > 0 ? false : true, InvasionWorld.invasionType > 0 ? false : true, false);
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            if (flags[0])
                InvasionWorld.invasionProgress = 0;
            else
                InvasionWorld.invasionProgress = 100;
            if (flags[1])
                InvasionWorld.invasionType = 0;
            else
                InvasionWorld.invasionType = 1;
        }
        public override void PostUpdate()
        {
            if (InvasionWorld.invasionType > 0 && !this.loaded)
            {
                Main.NewText(InvasionHandler.currentInvasion.beginMessage, 255, 60, 255, false);
            }
            this.loaded = true;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {
                    "invasionType",
                    InvasionWorld.invasionType
                },
                {
                    "invasionSizeStart",
                    InvasionWorld.invasionSizeStart
                },
                {
                    "invasionSize",
                    InvasionWorld.invasionSize
                },
                {
                    "invasionX",
                    InvasionWorld.invasionX
                },
                {
                    "invasionProgress",
                    InvasionWorld.invasionProgress
                },
                {
                    "invasionProgressMax",
                    InvasionWorld.invasionProgressMax
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            InvasionWorld.invasionType = tag.GetInt("invasionType");
            InvasionWorld.invasionSizeStart = tag.GetInt("invasionSizeStart");
            InvasionWorld.invasionSize = tag.GetInt("invasionSize");
            InvasionWorld.invasionX = tag.GetInt("invasionX");
            InvasionWorld.invasionProgress = tag.GetInt("invasionProgress");
            InvasionWorld.invasionProgressMax = tag.GetInt("invasionProgressMax");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            string[] splitInvasionData = reader.ReadString().Split(new char[]
            {
                ':'
            });
            InvasionWorld.invasionType = int.Parse(splitInvasionData[0]);
            InvasionWorld.invasionSizeStart = int.Parse(splitInvasionData[1]);
            InvasionWorld.invasionSize = int.Parse(splitInvasionData[2]);
            InvasionWorld.invasionX = int.Parse(splitInvasionData[3]);
            InvasionWorld.invasionProgress = int.Parse(splitInvasionData[4]);
            InvasionWorld.invasionProgressMax = int.Parse(splitInvasionData[5]);
            InvasionHandler.currentInvasion = InvasionHandler.GetInvasionInfo(InvasionWorld.invasionType);
            this.loaded = false;
        }
    }
}
