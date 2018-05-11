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
	public Transform pointPrefab;
	private const int RESOLUTION = 750;
	public Transform mao, cotovelo, ombro; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
	Vector2 m_p, c_p, o_p, grafico;
	float current_time_movement;
	bool t;
	int i;
	LineRenderer lineRenderer;
	public Color c1 = Color.black;
	public Color c2 = Color.red;
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

			grafico = new Vector2 (current_time_movement, Joint.Angle(m_p, c_p, c_p, o_p));

			SavePoints (grafico);

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

	static void SavePoints (Vector2 point) 
	
	{
		StringBuilder sb = new StringBuilder();

		sb.Append(point.x).Append(" ").Append(point.y).Append("\n");

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
		lineRenderer.positionCount = 5000;

		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
		lineRenderer.colorGradient = gradient;
	}

}
