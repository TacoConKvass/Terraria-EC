namespace EC_Experiments.Core;

public interface IComponent {
	private bool enabled;
	
	bool Enabled => enabled;
	
	bool SetEnabled(bool value) {}

	void OnEnable() {}
	void OnDisable() {}
}