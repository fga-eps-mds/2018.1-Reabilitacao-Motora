using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _Joint
{
	private static float Hypot (float a, float b)
	{
		return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
	}

	public static float Angle (Vector2 P, Vector2 Q, Vector2 R, Vector2 S)
	{
		float ux = P.x - Q.x;
		float uy = P.y - Q.y;

		float vx = R.x - S.x;
		float vy = R.y - S.y;

		float num = ux * vx + uy * vy;
		float den = Hypot(ux, uy) * Hypot(vx, vy);
		return (Mathf.Acos(num / den) * (180.0f / Mathf.PI));
	}
}