using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Cultists
{
    public class DuskCultArcher : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Dusk Cult Archer";
            npc.displayName = "Dusk Cult Archer";
            npc.width = 42;
            npc.height = 54;
            npc.damage = 120;
            npc.defense = 14;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0.45f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.CultistArcherWhite;
            animationType = NPCID.CultistArcherWhite;
        }

    }
}