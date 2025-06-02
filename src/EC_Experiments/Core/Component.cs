using rail;
using Terraria.ID;
using Terraria.ModLoader;

namespace EC_Experiments.Core;

public class Component<T> {
	public static string Name = nameof(T);

	[ReinitializeDuringResizeArrays]
	public static class Data {
		public static T?[] Items = ItemID.Sets.Factory.CreateNamedSet($"EC/{Name}").RegisterCustomSet<T?>(default);
		public static T?[] Projectiles = ProjectileID.Sets.Factory.CreateNamedSet($"EC/{Name}").RegisterCustomSet<T?>(default);
		public static T?[] NPCs = NPCID.Sets.Factory.CreateNamedSet($"EC/{Name}").RegisterCustomSet<T?>(default);
	}

	private bool enabled;

	public bool Enabled => enabled;

	public void SetEnabled(bool value) {
		if (enabled != value) {
			if (value) OnEnable();
			else OnDisable();

			enabled = value;
		}
	}

	public void OnEnable() { }
	
	public void OnDisable() { }
}