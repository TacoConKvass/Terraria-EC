using Terraria;
using Terraria.ModLoader;

namespace EC.Core;

public class ProjectileComponent : GlobalProjectile 
{
	public override string Name => GetType().FullName;

	public override bool InstancePerEntity { get; } = true;

	public bool Enabled { get; set; }

	public virtual void OnEnabled(Projectile projectile) { }
	
	public virtual void OnDisabled(Projectile projectile) { }
}
