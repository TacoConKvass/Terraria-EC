using EC.Core;

namespace EC.Data;

public class ProjectileData<T> : ProjectileComponent
{
	public T? Data { get; set; } = default;
}