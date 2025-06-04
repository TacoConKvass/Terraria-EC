using Terraria.ModLoader;

namespace EC.Core;

public class PlayerData<T, TManager> : ModPlayer
	where T : struct
	where TManager : Manager<T> {
	public T Data { get; set; }

	bool enabled;

	public bool Enabled => enabled;

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