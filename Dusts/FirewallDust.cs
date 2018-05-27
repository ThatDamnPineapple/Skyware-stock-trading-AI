using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Dusts
{
	public class FirewallDust : ModDust
	{
		int timer = 0;
		public override void OnSpawn(Dust dust)
		{
			dust.noLight = true;
		//	dust.color = new Color(188, 66, 244);
			dust.scale = 4f;
			dust.noGravity = true;
		}
		public override bool Update(Dust dust)
		{
			dust.velocity.X = 1f;
			dust.velocity.Y = 1f;
			//dust.position += dust.velocity;
			dust.rotation = 0;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0f, 1.5975f, 0f);
			dust.scale -= 0.02f;
			if (dust.scale < 3f)
			{
				dust.active = false;
			}
			return false;
		}
		
		
	}
}