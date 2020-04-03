using UnityEngine;

public abstract class PlayerPartJoint : MonoBehaviour
{
	protected static readonly Color GOOD_COLOR = Color.green;
	protected static readonly Color ERROR_COLOR = Color.red;
	protected static readonly Color OPTIONAL_COLOR = new Color(200, 200, 200);
	protected static readonly Color GUIDE_COLOR = Color.blue;

	public void CallJointUpdate() {
		JointUpdate();
	}

	protected abstract void JointUpdate();

	protected virtual bool isNotValid() {
		return true;
	}

	protected void SetGizmosColor() {
		Gizmos.color = isNotValid() ? ERROR_COLOR : GOOD_COLOR;
	}

	protected void GizmoPosition(Transform transform) {
		
		if (transform) Gizmos.DrawCube(transform.position, new Vector3(.1f, .1f, .1f));
	}

	protected void GizmoLine(Transform t1, Transform t2) {
		if (t1 && t2) Gizmos.DrawLine(t1.position, t2.position);
	}

	protected void GizmoLine(Transform t1, Vector3 t2) {
		if (t1) Gizmos.DrawLine(t1.position, t2);
	}

	protected void GizmoLine(Vector3 t1, Vector3 t2) {
		Gizmos.DrawLine(t1, t2);
	}

#if (UNITY_EDITOR)
	public void EditorJointUpdate() {
		JointUpdate();
	}
#endif
}
