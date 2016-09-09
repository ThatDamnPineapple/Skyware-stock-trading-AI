using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class Toxify : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Toxified";
			Main.buffTip[Type] = "Defense, attack, and regen decreased";
			 Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }
         public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense = (npc.defense / 100) * 85; //this line
			npc.damage = (npc.damage / 100) * 85;
        }
				public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen = 0;
			 player.statDefense = (player.statDefense / 100) * 85;
				player.magicDamage *= 0.85f;
			player.meleeDamage *= 0.85f;
			player.rangedDamage *= 0.85f;
			player.minionDamage *= 0.85f;
			player.thrownDamage *= 0.85f;
		}
    }
}
