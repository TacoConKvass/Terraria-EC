using EC.Core;

namespace EC.Data;

public class PlayerData<T> : PlayerComponent {
	public T? Data { get; set; } = default;
}
