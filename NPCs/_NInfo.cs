using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class NInfo : NPCInfo
    {
        public int fireStacks;
        public int nebulaFlameStacks;
        public int GhostJellyStacks;
        public bool amberFracture;

        public bool felBrand = false;
        public bool soulBurn = false;
        public bool SoulFlare = false;
        public bool starDestiny = false;

        public bool DoomDestiny = false;

        public bool sFracture = false;
        public bool Etrap = false;

        public int TikiStacks = 0;
        public int TikiSlot = 0;
        public TikiData[] TikiSources = new TikiData[Buffs.TikiInfestation.maxStacks];

        public int titanicSetStacks;
        public int duneSetStacks;

        public void AddTikiSource(Projectile projectile)
        {
            TikiSources[TikiSlot] = new TikiData(projectile);

            TikiSlot++;
            if (TikiSlot >= Buffs.TikiInfestation.maxStacks)
            {
                TikiSlot = 0;
            }
            if (TikiStacks < Buffs.TikiInfestation.maxStacks)
            {
                TikiStacks++;
            }
        }
    }

    public struct TikiData
    {
        public bool wasSpirit;
        public int owner;
        public int damage;

        public TikiData(Projectile source)
        {
            wasSpirit = source.type == Projectiles.Arrow.TikiBiter._ref.projectile.type;
            owner = source.owner;
            damage = source.damage;
        }
    }
}
