using UnityEngine;

public class WheelStickTest : MonoBehaviour {
	public float SpeedPerSecond = 1;

	// Update is called once per frame
	void Update() {
		float distance = Time.deltaTime * SpeedPerSecond;
		PlayerPartComponent[] parts = GetComponentsInChildren<PlayerPartComponent>();
		for (int i = 0; i < parts.Length; i++) {
			parts[i].CallAfterMovement(distance, 1.0f);
		}

	}
}
