using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChartRealTime : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab, mao, cotovelo, ombro, braco; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
	
	private const int RESOLUTION = 750;
	
	Vector2 m_p, c_p, o_p, grafico;

	float current_time_movement;
	bool t;
	int i;
	LineRenderer lineRenderer;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.blue;

	List <Vector3> points2;

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
		}
	}

	void FixedUpdate () 
	{
		if (t) 
		{
			current_time_movement += Time.fixedDeltaTime;

			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);

			grafico = new Vector2 (current_time_movement, _Joint.Angle(m_p, c_p, c_p, o_p));

			SavePoints ();

			if (i >= RESOLUTION) 
			{
				t = false;
			}

			float divScale = (70 * RESOLUTION)/(float)RESOLUTION;
			float step = 2f / divScale;
			Vector3 scale = Vector3.one * step;
			Vector3 position = new Vector3 (0f,0f,12);
			Transform point = Instantiate(pointPrefab);
			position.x = (grafico.x) + 0.05f;
			position.y = (grafico.y/24);
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points2.Add (point.position);

			lineRenderer.SetPositions (points2.ToArray());
			i++;
		}
	}

	private void SavePoints () 
	{
		StringBuilder sb = new StringBuilder();

		sb.Append(current_time_movement).Append(" ").Append(mao.localPosition.x).Append(" ").Append(mao.localPosition.y).Append(" ").Append(mao.localPosition.z);
		sb.Append(" ").Append(mao.localEulerAngles.x).Append(" ").Append(mao.localEulerAngles.y).Append(" ").Append(mao.localEulerAngles.z);

		sb.Append(" ").Append(cotovelo.localPosition.x).Append(" ").Append(cotovelo.localPosition.y).Append(" ").Append(cotovelo.localPosition.z);
		sb.Append(" ").Append(cotovelo.localEulerAngles.x).Append(" ").Append(cotovelo.localEulerAngles.y).Append(" ").Append(cotovelo.localEulerAngles.z);

		sb.Append(" ").Append(ombro.localPosition.x).Append(" ").Append(ombro.localPosition.y).Append(" ").Append(ombro.localPosition.z);
		sb.Append(" ").Append(ombro.localEulerAngles.x).Append(" ").Append(ombro.localEulerAngles.y).Append(" ").Append(ombro.localEulerAngles.z);

		sb.Append(" ").Append(braco.localPosition.x).Append(" ").Append(braco.localPosition.y).Append(" ").Append(braco.localPosition.z);
		sb.Append(" ").Append(braco.localEulerAngles.x).Append(" ").Append(braco.localEulerAngles.y).Append(" ").Append(braco.localEulerAngles.z);

		sb.Append("\n");

		string path = Application.dataPath + "/Exercicios/" + GlobalController.instance.exercise.pontosExercicio;

		File.AppendAllText(path, sb.ToString());
	}


	void Awake()
	{	
		points2 = new List<Vector3>();
		t = false;
		i = 0;
		current_time_movement = 0;

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
		lineRenderer.widthMultiplier = 0.4f;
		lineRenderer.positionCount = RESOLUTION + 1;

		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
		lineRenderer.colorGradient = gradient;
	}

}
