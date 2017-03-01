/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class ReachObserver : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Reach Observer";
            npc.displayName = "Reach Observer";
            npc.width = 24;
            npc.height = 24;
            npc.damage = 21;
            npc.defense = 3;
            npc.lifeMax = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 460f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 2;
            npc.noGravity = true;
            aiType = NPCID.TheHungryII;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneReach && !Main.dayTime ? 3f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Reach3"));
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 1)
            {
                int Bark = Main.rand.Next(2) + 1;
                for (int J = 0; J <= Bark; J++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientBark"));
                }
            }
        }
        public override void AI()
        {
            npc.rotation += 0.3f;
        }
    }
}*/
