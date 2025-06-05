using EC.Components;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EC.Content;

using JumpData = (int Delay, float Height, float Distance);

public class TestNPC : ModNPC {
	public override string Texture => $"Terraria/Images/NPC_{NPCID.GiantWormTail}";

	public override void SetDefaults() {
		NPC.Size = new Vector2(30);
		NPC.lifeMax = 200;

		NPC.noGravity = false;
	}

	public enum Actions {
		Jump
	}

	public Actions State { get; set; } = Actions.Jump;

	public JumpData a = new JumpData(60, 5, 5);

	public override void AI() {
		if (State == Actions.Jump) 
			NPC.GetGlobalNPC<JumpNPC>().EnableWith(new JumpData() { Delay = 60, Height = 100, Distance = 20 });
	}
}