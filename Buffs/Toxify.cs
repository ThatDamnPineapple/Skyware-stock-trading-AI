using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
	public class Toxify : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Toxify");
			Description.SetDefault("Reduced damage, life regen, and defense");

			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense = (int)Math.Round(npc.defDefense * .85f);
			npc.damage = (int)Math.Round(npc.defDamage * .85f);
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			player.lifeRegen = 0;
			player.statDefense = (int)Math.Round(player.statDefense * .85f);
			player.magicDamage *= 0.85f;
			player.meleeDamage *= 0.85f;
			player.rangedDamage *= 0.85f;
			player.minionDamage *= 0.85f;
			player.thrownDamage *= 0.85f;

			modPlayer.toxify = true;
		}
	}
}
