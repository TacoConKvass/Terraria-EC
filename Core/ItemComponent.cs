using Terraria;
using Terraria.ModLoader;

namespace EC.Core;

public class ItemComponent : GlobalItem 
{
	public override string Name => GetType().FullName;

	public override bool InstancePerEntity { get; } = true;

	public bool Enabled { get; set; }

	public virtual void OnEnabled(Item item) { }
	
	public virtual void OnDisabled(Item item) { }
}
