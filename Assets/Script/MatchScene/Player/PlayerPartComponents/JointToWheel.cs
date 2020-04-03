using UnityEngine;

public class JointToWheel : PlayerPartJoint {

	public Transform  AnchorOnWheel;

	protected float DistanceFromWheelCenter;

	protected override bool isNotValid() {
		return AnchorOnWheel == null;
	}
	

	protected override void JointUpdate() {
		if (isNotValid()) return;
		
		transform.position = AnchorOnWheel.position;
	}

	public void OnDrawGizmosSelected() {
		SetGizmosColor();
		GizmoPosition(AnchorOnWheel ? AnchorOnWheel : transform);
	}
}
