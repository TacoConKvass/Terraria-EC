using Terraria;
using Terraria.ModLoader;

namespace EC.Core;

public class NPCComponent : GlobalNPC 
{
	public override string Name => GetType().FullName;

	public override bool InstancePerEntity { get; } = true;

	public bool Enabled { get; set; }

	public virtual void OnEnabled(NPC npc) { }
	
	public virtual void OnDisabled(NPC npc) { }
}