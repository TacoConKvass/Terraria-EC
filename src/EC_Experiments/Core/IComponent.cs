namespace EC.Core;

public interface IComponent<T> 
	where T : struct
{
	T Data { get; set; }
	bool Enabled { get; set; }

	void SetEnabled(bool value) {
		if (Enabled != value) {
			if (value) OnEnabled();
			else OnDisabled();
		}

		Enabled = value;
	}

	void EnableWithComponentData(T data) {
		Data = data;
		SetEnabled(true);
	}

	void OnEnabled() { }
	void OnDisabled() { }
}