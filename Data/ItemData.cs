using EC.Core;

namespace EC.Data;

public class ItemData<T> : ItemComponent {
	public T? Data { get; set; } = default;
}
