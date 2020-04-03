using UnityEngine;
using Utils;

public class TwoPointJointPart : PlayerPartJoint {

	public Transform Anchor;
	public Transform DestinationTarget;

	protected override bool isNotValid() {
		return Anchor == null || DestinationTarget == null;
	}

	protected override void JointUpdate() {
		if (isNotValid()) return;

		float radians = MathUtils2.GetRadiansBetween2Positions(Anchor.position, DestinationTarget.position);
		transform.position = Anchor.position;
		transform.eulerAngles = new Vector3(.0f, .0f, radians * Mathf.Rad2Deg);
	}

	private void OnDrawGizmosSelected() {
		SetGizmosColor();
		GizmoPosition(Anchor);
		GizmoPosition(DestinationTarget);
		GizmoLine(Anchor, DestinationTarget);
	}
}
