using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Chompasaur : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chompasaur");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }
        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 46;
            npc.damage = 55;
            npc.defense = 18;
            npc.lifeMax = 240;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 9260f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            aiType = NPCID.Unicorn;
            animationType = NPCID.Zombie;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.player.ZoneUndergroundDesert ? 0.16f : 0f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(25) == 1)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FossilFlower"));
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Chompasaur1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Chompasaur2"), 1f);
            }
        }
    }
}
