using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class Ki11H3ad : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Ki11H3ad";
            npc.displayName = "Ki11H3ad";
            npc.width = 17;
            npc.height = 21;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 85;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[4];
            aiType = 85;
            animationType = 85;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
    }
}
