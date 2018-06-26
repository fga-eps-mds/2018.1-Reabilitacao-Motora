using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Descrever aqui o que essa classe realiza.
 */
public static class GetMovementPoints
{
	public static void SavePoints (float current_time_movement, string folder, string path, Transform mao, Transform cotovelo, Transform ombro, Transform braco, bool sensor) 
	{
		StringBuilder sb = new StringBuilder();
		if (!sensor)
		{
			sb.Append(current_time_movement);
			sb.Append(" ").Append(mao.localPosition.x).Append(" ").Append(mao.localPosition.y).Append(" ").Append(mao.localPosition.z).Append(" ");
			sb.Append(mao.localEulerAngles.x).Append(" ").Append(mao.localEulerAngles.y).Append(" ").Append(mao.localEulerAngles.z).Append(" ");

			sb.Append(cotovelo.localPosition.x).Append(" ").Append(cotovelo.localPosition.y).Append(" ").Append(cotovelo.localPosition.z).Append(" ");
			sb.Append(cotovelo.localEulerAngles.x).Append(" ").Append(cotovelo.localEulerAngles.y).Append(" ").Append(cotovelo.localEulerAngles.z).Append(" ");

			sb.Append(ombro.localPosition.x).Append(" ").Append(ombro.localPosition.y).Append(" ").Append(ombro.localPosition.z).Append(" ");
			sb.Append(ombro.localEulerAngles.x).Append(" ").Append(ombro.localEulerAngles.y).Append(" ").Append(ombro.localEulerAngles.z).Append(" ");

			sb.Append(braco.localPosition.x).Append(" ").Append(braco.localPosition.y).Append(" ").Append(braco.localPosition.z).Append(" ");
			sb.Append(braco.localEulerAngles.x).Append(" ").Append(braco.localEulerAngles.y).Append(" ").Append(braco.localEulerAngles.z).Append("\n");
		}
		else
		{
			sb.Append((int)current_time_movement);
			sb.Append("\n");
		}
		// /movimentos/
		string file = Application.dataPath + folder + path;
		File.AppendAllText(file, sb.ToString());
	}

	public static void LoadLineRenderer (ref GameObject gameObject, ref LineRenderer lineRenderer, Color c1, Color c2)
	{
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = 4000;
		lineRenderer.sortingOrder = 5;
		lineRenderer.positionCount = 2;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys( 
			new [] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new [] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f)}
		);
		lineRenderer.colorGradient = gradient;
		lineRenderer.useWorldSpace = false;
		lineRenderer.alignment = LineAlignment.Local;
	}

	public static void graphSpawner (Transform transform, Transform pointPrefab, Transform mao, Transform cotovelo, Transform ombro, float current_time,
		ref LineRenderer lineRenderer)
	{
		float step = 2f / 70;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;
		Vector2 m_p, c_p, o_p, grafico;

		m_p = new Vector2 (mao.position.x, mao.position.y);
		c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
		o_p = new Vector2 (ombro.position.x, ombro.position.y);
		grafico = new Vector2 (current_time, _Joint.Angle(m_p, c_p, o_p, c_p));

		Transform point = Transform.Instantiate(pointPrefab);
		position.x = (grafico.x) + 0.05f;
		position.y = (grafico.y/24);
		position.z = 0.0f;
		point.localPosition = position;
		point.localScale = scale;
		point.SetParent (transform, false);

		lineRenderer.positionCount++; 
		lineRenderer.SetPosition(lineRenderer.positionCount-1, point.localPosition);
	}
}
