using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class ElectricEel : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Electric Eel";
            npc.displayName = "Electric Eel";
            npc.width = 66;
            npc.height = 18;
            npc.damage = 25;
            npc.defense = 12;
            npc.lifeMax = 125;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .35f;
            npc.aiStyle = 16;
            npc.noGravity = true;
            Main.npcFrameCount[npc.type] = 4;
            aiType = NPCID.Arapaima;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 53 || tile == 112 || tile == 116 || tile == 234) && spawnInfo.water && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Eel_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Eel_Gore_2"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.Electrified, 180, true);
            }
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
    }
}
