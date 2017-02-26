/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class ShrapnelZombie : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shrapnel Zombie";
            npc.displayName = "Shrapnel Zombie";
            npc.width = 17;
            npc.height = 21;
            npc.damage = 39;
            npc.defense = 8;
            npc.lifeMax = 240;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 860f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 243);
                Gore.NewGore(npc.position, npc.velocity, 244);
                Gore.NewGore(npc.position, npc.velocity, 245);


                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 160);
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.BrokenArmor, 300);
        }
    }
}*/
