using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class Argargothite : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Argargothite";
            npc.displayName = "Argargothite";
            npc.width = 64;
            npc.height = 64;
            npc.damage = 30;
            npc.defense = 26;
            npc.lifeMax = 400;
            npc.soundHit = 4;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 44;
            npc.noGravity = true;
            npc.noTileCollide = true;
            aiType = NPCID.FlyingFish;
        }
    }
}