using UnityEngine;

public class WheelPart : PlayerPartComponent {
	[SerializeField]
	private float Diameter;
	[SerializeField]
	private bool DiameterResizeWithScaleX = true;
	private float circumference;
	private float oneDegreeCircumference;
	
	public bool FlipDirection = false;
	public PlayerPartJoint[] Joints = new PlayerPartJoint[0];


	public void Start() {
		UpdateDimensions();
	}

	private void UpdateDimensions() {
		circumference = Diameter * Mathf.PI;
		oneDegreeCircumference = circumference / 360.0f * (DiameterResizeWithScaleX ? transform.localScale.x : 1.0f);
	}

	protected override void UpdateAfterMovement(float distance, float direction) {
		RotateWheel(distance, direction);
	}

	public void OnDrawGizmos() {
		Gizmos.color = Diameter > .0f ? Color.green : Color.red;
		Gizmos.DrawWireSphere(transform.position, Diameter / 2.0f);
	}

	protected void RotateWheel(float distance, float direction) {
		transform.Rotate(.0f, .0f, distance / oneDegreeCircumference * direction);
		for (int i = 0; i < Joints.Length; i++) {
			if (Joints[i]) {
				Joints[i].CallJointUpdate();
			}
		}
	}

#if (UNITY_EDITOR)
	public void EditorRotateWheel(float distance) {
		UpdateDimensions();
		RotateWheel(distance, 1.0f);
	}
#endif
}
