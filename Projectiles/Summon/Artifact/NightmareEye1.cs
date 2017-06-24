using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SpiritMod.Projectiles.Summon.Artifact
{
    public class NightmareEye1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Eye");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.minion = true;
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4)
            {
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
                projectile.frameCounter = 0;
            }
            {
                projectile.ai[1] += 1f;
                if (projectile.ai[1] >= 7200f)
                {
                    projectile.alpha += 5;
                    if (projectile.alpha > 255)
                    {
                        projectile.alpha = 255;
                        projectile.Kill();
                    }
                }
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] >= 10f)
                {
                    projectile.localAI[0] = 0f;
                    int num416 = 0;
                    int num417 = 0;
                    float num418 = 0f;
                    int num419 = projectile.type;
                    for (int num420 = 0; num420 < 1000; num420++)
                    {
                        if (Main.projectile[num420].active && Main.projectile[num420].owner == projectile.owner && Main.projectile[num420].type == num419 && Main.projectile[num420].ai[1] < 3600f)
                        {
                            num416++;
                            if (Main.projectile[num420].ai[1] > num418)
                            {
                                num417 = num420;
                                num418 = Main.projectile[num420].ai[1];
                            }
                        }
                        if (num416 > 1)
                        {
                            Main.projectile[num417].netUpdate = true;
                            Main.projectile[num417].ai[1] = 36000f;
                            return;
                        }
                    }
                }
            }
        }
    }
}