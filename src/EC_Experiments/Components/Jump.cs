using Daybreak.Common.Features.Hooks;
using EC.Core;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EC.Components;

using JumpData = (int Delay, float Height, float Distance);

public class JumpNPC : NPCData<JumpData, JumpManager> {
	public int Timer = 0;
}

public class JumpManager : Manager<JumpData> {
	public override string ComponentName => "Jump";
	public override string ComponentDescription => "Makes the affected Entity jump when enabled";

	public override void OnEnable(Entity entity) {
		if (entity is NPC npc) npc.GetGlobalNPC<JumpNPC>().Timer = 0;
	}
}

public class Jump : ILoadable {

	void ILoadable.Load(Mod mod) {
		GlobalNPCHooks.AI.Event += static (GlobalNPC _, NPC npc) => {
			JumpNPC component = npc.GetGlobalNPC<JumpNPC>();
			if (component.Enabled) return;

			JumpData data = component.Data;
			if (component.Timer++ < data.Delay) return;
			else if (component.Timer == data.Delay) npc.velocity = new Vector2();
			else if (npc.collideY) component.SetEnabled(false);
		};
	}

	void ILoadable.Unload() { }
}