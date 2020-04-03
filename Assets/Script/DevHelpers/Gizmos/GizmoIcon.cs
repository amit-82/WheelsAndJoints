using UnityEngine;

public class GizmoIcon : MonoBehaviour {
	public string IconFile;

	private void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, IconFile, true);
	}
}
