using UnityEngine;
using Utils;

public class OnTrackJoint : PlayerPartJoint {

	public Transform Anchor;
	public Transform TrackNearEdge;
	public Transform TrackFarEdge;
	public float JointLength = .0f;

	protected override bool isNotValid() {
		return JointLength == .0f || Anchor == null || TrackFarEdge == null || TrackNearEdge == null;
	}

	protected override void JointUpdate() {
		if (isNotValid()) return;

		transform.position = Anchor.position;
		Vector3 P1;
		Vector3 P2;
		float radians;
		int matchedPointCount = MathUtils2.FindLineCircleIntersections(Anchor.position.x, Anchor.position.y, JointLength, TrackFarEdge.position, TrackNearEdge.position, out P1, out P2);
		switch(matchedPointCount) {
			case 1:
				radians = MathUtils2.GetRadiansBetween2Positions(Anchor.position, P1);
				transform.eulerAngles = new Vector3(.0f, .0f, radians * Mathf.Rad2Deg);
				break;

			case 2:
				radians = MathUtils2.GetRadiansBetween2Positions(Anchor.position, MathUtils2.GetNearestPoint(TrackFarEdge.position, P1, P2));
				transform.eulerAngles = new Vector3(.0f, .0f, radians * Mathf.Rad2Deg);
				break;

			default:
				Debug.Log("no point");
				break;
		}
	}

	private void OnDrawGizmosSelected() {
		SetGizmosColor();
		GizmoPosition(Anchor);
		GizmoPosition(TrackNearEdge);
		GizmoPosition(TrackFarEdge);
		GizmoLine(TrackNearEdge, TrackFarEdge);

		// draw a line from anchor, length = JointLength and rotated has game object
		Gizmos.color = GUIDE_COLOR;
		float rotationRadians = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		Vector3 endOfLengthRelative = new Vector3(JointLength * Mathf.Cos(rotationRadians), JointLength * Mathf.Sin(rotationRadians));
		Vector3 endOfLengthWorld = transform.position + endOfLengthRelative;
		GizmoLine(transform, endOfLengthWorld);
		Gizmos.DrawWireSphere(transform.position, JointLength);
		Gizmos.DrawWireSphere(endOfLengthWorld, JointLength * .05f);

	}
}
