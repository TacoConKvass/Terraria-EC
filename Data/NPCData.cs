using EC.Core;

namespace EC.Data;

public class NPCData<T> : NPCComponent {
	public T? Data { get; set; } = default;
}
