using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CrimsonBrutalist : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Crimson Brutalist";
            npc.displayName = "Crimson Brutalist";
            npc.width = 42;
            npc.height = 52;
            npc.damage = 35;
            npc.defense = 10;
            npc.lifeMax = 180;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 8900f;
            npc.knockBackResist = .95f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryBones];
            aiType = NPCID.AngryBones;
            animationType = NPCID.AngryBones;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon ? 0.03f : 0f;
        }
        public override void NPCLoot()
        {
            int Techs = Main.rand.Next(4, 7);
            for (int J = 0; J <= Techs; J++)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone);
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Brutalist2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Brutalist1"), 1f);
            }
            if (Main.rand.Next(6) == 1)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Tenderizer"), 1);
			}
        }
    }
}
