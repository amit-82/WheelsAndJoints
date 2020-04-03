using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WheelPart))]
[CanEditMultipleObjects]
public class WheelPartEditor : Editor
{
	private float distance = .1f;
	private bool clockWise = true;
	private bool playWhileSelected = false;

	public override void OnInspectorGUI() {

		DrawDefaultInspector();

		GUILayout.Space(10.0f);

		GUILayout.Label("Simulating distance");

		distance = GUILayout.HorizontalSlider(distance, .0f, 2.0f);
		clockWise = GUILayout.Toggle(clockWise, "CW");
		playWhileSelected = GUILayout.Toggle(playWhileSelected, "Play while selected");


		GUILayout.Label($"distance traveled per click: {distance * (clockWise ? -1.0f : 1.0f)}");
		
		if (GUILayout.Button("simultate distance")) {
			RotateWheels();
		}

		if (playWhileSelected) {
			RotateWheels();
		}
	}    

	private void RotateWheels() {
		for (var i = 0; i < targets.Length; i++) {
			(targets[i] as WheelPart).EditorRotateWheel(distance * (clockWise ? -1.0f : 1.0f));
		}
	}
}
