// using Daybreak.Core.Hooks;
using EC_Experiments.Core;
using Terraria.ModLoader;

namespace EC_Experiments.Components;

public class Test : Component<Test.Data>, ILoadable {
	public struct Data { }

	void ILoadable.Load(Mod mod) {
		
	}

	void ILoadable.Unload() { }
}
