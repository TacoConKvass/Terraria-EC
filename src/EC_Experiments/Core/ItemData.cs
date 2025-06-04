using Terraria.ModLoader;
using Terraria;

namespace EC.Core;

public class ItemData<T, TManager> : GlobalItem
	where T : struct
	where TManager : Manager<T> {
	public override bool InstancePerEntity { get; } = true;

	public T Data { get; set; }

	bool enabled;

	public bool Enabled => enabled;

	private Entity Entity { get; set; } = null!;

	public override void SetDefaults(Item entity) {
		Data = ModContent.GetInstance<TManager>().Items[entity.type];
		Entity = entity;
		enabled = !Data.Equals(new T());
	}

	public void SetEnabled(bool value) {
		if (enabled != value) {
			if (value) ModContent.GetInstance<TManager>().OnEnable(Entity);
			else ModContent.GetInstance<TManager>().OnDisable(Entity);
		}
		enabled = value;
	}

	public void EnableWith(T data) {
		Data = data;
		SetEnabled(true);
	}
}