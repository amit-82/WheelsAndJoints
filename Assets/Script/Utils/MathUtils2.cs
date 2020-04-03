
using UnityEngine;

namespace Utils {

	public class MathUtils2 {

		public static float GetRadiansBetween2Positions(Vector3 anchor, Vector3 target) {
			return Mathf.Atan2(target.y - anchor.y, target.x - anchor.x);
		}

		public static Vector2 GetNearestPoint(Vector2 target, Vector2 opt1, Vector2 opt2) {
			return Vector2.Distance(target, opt1) <= Vector2.Distance(target, opt2) ? opt1 : opt2;
		}

		public static Vector3 GetNearestPoint(Vector3 target, Vector3 opt1, Vector3 opt2) {
			return Vector3.Distance(target, opt1) <= Vector3.Distance(target, opt2) ? opt1 : opt2;
		}

		public bool GetPointOnSegmentInRadius(Vector3 segmentP1, Vector3 segmentP2, Vector3 anchor, float radius, out Vector3 pointOnSegment) {
			Vector3 intersection1;
			Vector3 intersection2;
			int foundIntersectionsCount = FindLineCircleIntersections(anchor.x, anchor.y, radius, segmentP1, segmentP2, out intersection1, out intersection2);
			switch (foundIntersectionsCount) {
				case 1:
					pointOnSegment = intersection1;
					return true;
				case 2:
					pointOnSegment = GetNearestPoint(segmentP1, intersection1, intersection2);
					return true;
			}
			pointOnSegment = Vector3.zero;
			return false;

		}

		// Find the points of intersection.
		public static int FindLineCircleIntersections(float cx, float cy, float radius, Vector3 point1, Vector3 point2, out Vector3 intersection1, out Vector3 intersection2) {
			float dx, dy, A, B, C, det, t;

			dx = point2.x - point1.x;
			dy = point2.y - point1.y;

			A = dx * dx + dy * dy;
			B = 2 * (dx * (point1.x - cx) + dy * (point1.y - cy));
			C = (point1.x - cx) * (point1.x - cx) +
				(point1.y - cy) * (point1.y - cy) -
				radius * radius;

			det = B * B - 4 * A * C;
			if ((A <= 0.0000001) || (det < 0)) {
				// No real solutions.
				intersection1 = new Vector3(float.NaN, float.NaN);
				intersection2 = new Vector3(float.NaN, float.NaN);
				return 0;
			} else if (det == 0) {
				// One solution.
				t = -B / (2 * A);
				intersection1 =
					new Vector3(point1.x + t * dx, point1.y + t * dy);
				intersection2 = new Vector3(float.NaN, float.NaN);
				return 1;
			} else {
				// Two solutions.
				t = (float)((-B + Mathf.Sqrt(det)) / (2 * A));
				intersection1 =
					new Vector3(point1.x + t * dx, point1.y + t * dy);
				t = (float)((-B - Mathf.Sqrt(det)) / (2 * A));
				intersection2 =
					new Vector3(point1.x + t * dx, point1.y + t * dy);
				return 2;
			}
		}
	}
}
