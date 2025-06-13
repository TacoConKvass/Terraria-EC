using Terraria;
using Terraria.ModLoader;

namespace EC.Core;

public class PlayerComponent : ModPlayer 
{
	public override string Name => GetType().FullName;

	public bool Enabled { get; set; }

	public virtual void OnEnabled(Player player) { }
	
	public virtual void OnDisabled(Player player) { }
}
