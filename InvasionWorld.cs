/*using System;
using System.IO;
using Terraria;
using Terraria.ID;
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

        bool loaded = false;
        
        public override void PostUpdate()
        {
            if (invasionType > 0 && !loaded)
            {
                Main.NewText(InvasionHandler.currentInvasion.beginMessage, 255, 60, 255);
            }

            loaded = true;
        }

         public override TagCompound Save()
        {
            //string saveString = invasionType + ":" + invasionSizeStart  + ":" + invasionSize + ":" + invasionX + ":" + invasionProgress + ":" + invasionProgressMax;
            //writer.Write(saveString);

            return new TagCompound {
                {"invasionType", invasionType},
                {"invasionSizeStart", invasionSizeStart},
                {"invasionSize", invasionSize},
                {"invasionX", invasionX},
                {"invasionProgress", invasionProgress},
                {"invasionProgressMax", invasionProgressMax},
            };

            //invasionType = invasionSizeStart = invasionSize = invasionX = invasionProgress = invasionProgressMax = 0;
        }

        public override void Load(TagCompound tag)
        {
            invasionType = tag.GetInt("invasionType");
            invasionSizeStart = tag.GetInt("invasionSizeStart");
            invasionSize = tag.GetInt("invasionSize");
            invasionX = tag.GetInt("invasionX");
            invasionProgress = tag.GetInt("invasionProgress");
            invasionProgressMax = tag.GetInt("invasionProgressMax");
        }
        public override void LoadLegacy(BinaryReader reader)
		{
            string[] splitInvasionData = reader.ReadString().Split(':');

            // Load values into InvasionWorld.
            invasionType = int.Parse(splitInvasionData[0]);

            invasionSizeStart = int.Parse(splitInvasionData[1]);
            invasionSize = int.Parse(splitInvasionData[2]);

            invasionX = int.Parse(splitInvasionData[3]);

            invasionProgress = int.Parse(splitInvasionData[4]);
            invasionProgressMax = int.Parse(splitInvasionData[5]);

            // Load values into InvasionHandler.
            InvasionHandler.currentInvasion = InvasionHandler.GetInvasionInfo(invasionType);
            loaded = false;
        }
    }
}
*/
