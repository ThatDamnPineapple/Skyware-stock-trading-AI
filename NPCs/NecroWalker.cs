using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class NecroWalker : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Necro Walker";
            npc.displayName = "Necro Walker";
            npc.width = 32;
            npc.height = 52;
            npc.damage = 28;
            npc.defense = 13;
            npc.lifeMax = 190;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 8060f;
            npc.knockBackResist = .37f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryBones];
            aiType = NPCID.AngryBones;
            animationType = NPCID.AngryBones;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon ? 0.03f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Skeleton_head"), 1f);
			}
        }
        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, 12);
            }
        }
    }
}
