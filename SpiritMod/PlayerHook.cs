using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Mounts;

namespace SpiritMod
{
	class PlayerHook : ModPlayer
	{
		public bool onGround = false;
		public bool moving = false;
		public bool flying = false;
		public bool swimming = false;
		
		public bool copterBrake = false;
		public bool copterFiring = false;
		public int copterFireFrame = 1000;

		public int beetleStacks = 1;

		public bool runicSet = false;

		public bool unboundSoulMinion = false;

		public override void FrameEffects()
		{
			//Hide players wings, etc. when mounted
			if (player.mount.Active)
			{
				int mount = player.mount.Type;
				if (mount == CandyCopter._ref.Type)
				{
					//Supposed to make players legs disappear, but only makes them skin-colored.
					player.legs = CandyCopter._outfit;
					player.wings = -1;
					player.back = -1;
					player.shield = -1;
					//player.handoff = -1;
					//player.handon = -1;
				} else if (mount == Drakomire._ref.Type)
				{
					player.wings = -1;
				}
			}
		}

		//public override void ModifyDrawLayers(List<PlayerLayer> layers)
		//{
		//	for (int i = 0; i < layers.Count; i++)
		//	{
		//		if ((this.drakomireMount || this.basiliskMount) && layers[i].Name == "Wings")
		//		{
		//			layers[i].visible = false;
		//		}
		//	}
		//}

		public override void PostUpdateRunSpeeds()
		{
			if (copterBrake && player.mount.Active && player.mount.Type == CandyCopter._ref.Type)
			{
				//Prevent horizontal movement
				player.maxRunSpeed = 0f;
				player.runAcceleration = 0f;
				//Deplete horizontal velocity
				if (player.velocity.X > CandyCopter.groundSlowdown)
				{
					player.velocity.X -= CandyCopter.groundSlowdown;
				} else if (player.velocity.X < -CandyCopter.groundSlowdown)
				{
					player.velocity.X += CandyCopter.groundSlowdown;
				} else
				{
					player.velocity.X = 0f;
				}
				//Prevent further depletion by game engine
				player.runSlowdown = 0f;
			}
		}

		public override void ResetEffects()
		{
			//Reset all
			runicSet = false;
			unboundSoulMinion = false;

			if (player.HasBuff(Buffs.BeetleFortitude._ref.Type) < 0)
			{
				beetleStacks = 1;
			}

			copterFireFrame++;

			onGround = false;
			moving = false;
			flying = false;
			swimming = false;

			if (player.velocity.Y != 0f)
			{
				if (player.mount.Active && player.mount.FlyTime > 0 && player.jump == 0 && player.controlJump && !player.mount.CanHover)
				{
					flying = true;
				} else if (player.wet)
				{
					swimming = true;
				}
			} else
			{
				onGround = true;
			}
			if (player.velocity.X != 0f)
			{
				moving = true;
			}
		}
	}
}
