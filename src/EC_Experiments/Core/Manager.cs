using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EC.Core;

public class Manager<T> : ModSystem
	where T : struct {
	public T[] Items = [];
	public T[] NPCs = [];
	public T[] Projectiles = [];

	private readonly string default_name = typeof(T).Name;

	public virtual string ComponentName => default_name;
	public virtual string ComponentDescription => "";

	public virtual object[] ItemInputs => [];
	public virtual object[] NPCInputs => [];
	public virtual object[] ProjectileInputs => [];

	public override void ResizeArrays() {
		string name = ComponentName;
		string description = ComponentDescription;
		this.Items = ItemID.Sets.Factory.CreateNamedSet($"EC/{name}").Description(description).RegisterCustomSet<T>(new(), ItemInputs);
		this.NPCs = NPCID.Sets.Factory.CreateNamedSet($"EC/{name}").Description(description).RegisterCustomSet<T>(new(), NPCInputs);
		this.Projectiles = ProjectileID.Sets.Factory.CreateNamedSet($"EC/{name}").Description(description).RegisterCustomSet<T>(new(), ProjectileInputs);
	}

	public virtual void OnEnable(Entity entity) { }
	public virtual void OnDisable(Entity entity) { }
}