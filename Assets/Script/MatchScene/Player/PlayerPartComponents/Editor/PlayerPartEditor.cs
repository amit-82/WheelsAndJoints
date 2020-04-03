using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerPartJoint))]
public class PlayerPartEditor : Editor
{
	public override void OnInspectorGUI() {

		DrawDefaultInspector();
		
		if (GUILayout.Button("reposition")) {
			(target as PlayerPartJoint).EditorJointUpdate();
			EditorUtility.SetDirty(target);
		}
	}    
}
