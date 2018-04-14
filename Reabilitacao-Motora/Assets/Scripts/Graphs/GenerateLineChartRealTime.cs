using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChartRealTime : MonoBehaviour
{
	public Transform x_axis;
	public Transform pointPrefab;
	public int resolution = 750;
	public Transform mao, cotovelo, ombro; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
	Vector2 m_p, c_p, o_p, grafico;
	float current_time_movement = 0;
	bool t = false;
	int i = 0;
	LineRenderer lineRenderer;
	public Color c1 = Color.black;
	public Color c2 = Color.red;
	List <Vector3> points2;

	public Transform mainCamera, xEnd;
	private int mdelta = 4;

	public static float hypot(float a, float b)
	{
		return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
	}

	float angle(Vector2 P, Vector2 Q, Vector2 R, Vector2 S)
	{
		float ux = P.x - Q.x;
		float uy = P.y - Q.y;

		float vx = R.x - S.x;
		float vy = R.y - S.y;

		float num = ux * vx + uy * vy;
		float den = hypot(ux, uy) * hypot(vx, vy);

		return (Mathf.Acos(num / den) * (180.0f / Mathf.PI));
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = !t;
		}
	}


	void FixedUpdate () {
		if (t) 
		{
			current_time_movement += Time.fixedDeltaTime;
			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);

			grafico = new Vector2 (current_time_movement, angle (m_p, c_p, c_p, o_p));

			if (i >= 750) {
				x_axis.localScale = new Vector3 (x_axis.localScale.x, x_axis.localScale.y + 0.02f, x_axis.localScale.z);
				x_axis.localPosition = new Vector3 (x_axis.localScale.y/2f, x_axis.localPosition.y, x_axis.localPosition.z);
				lineRenderer.positionCount++;
				resolution++;
				Vector3 pos = Camera.main.WorldToScreenPoint(xEnd.transform.position);

				if (pos.x >= Screen.width - mdelta) {
					mainCamera.position = new Vector3 (mainCamera.position.x + 6f, mainCamera.position.y, mainCamera.position.z);
				}
			}

	        float divScale = (70 * resolution)/750f;
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


	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Awake()
	{	
		points2 = new List<Vector3>();
		t = new bool();
		t = false;
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
		lineRenderer.widthMultiplier = 0.4f;
		lineRenderer.positionCount = 5000;

	// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
		lineRenderer.colorGradient = gradient;
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
}
