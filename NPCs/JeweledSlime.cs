using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class JeweledSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Jeweled Slime";
            npc.displayName = "Jeweled Slime";
            npc.width = 16;
            npc.height = 12;
            npc.damage = 40;
            npc.defense = 12;
            npc.lifeMax = 180;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 5060f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
             int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Geode"), Main.rand.Next(1) + 2);
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60);
            target.AddBuff(BuffID.Frostburn, 60);
            target.AddBuff(BuffID.OnFire, 60);
        }

    }
}
