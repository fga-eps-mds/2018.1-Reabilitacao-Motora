using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Pega pontos do movimento para o gráfico estático.
*/
public class GenerateLineChartRealTime : MonoBehaviour
{
	public Transform x_axis;
	public Transform pointPrefab;
	public int resolution = 750;
	public Transform mao, cotovelo, ombro;
	Vector2 m_p, c_p, o_p, grafico;
	float current_time_movement = 0;
	bool t = false;
	int i = 0;
	LineRenderer lineRenderer;
	public Color c1 = Color.black;
	public Color c2 = Color.red;
	public List <Vector3> points2;

	/**
	* Calcula a hipotenusa.
	*/
	public static float hypot(float a, float b)
	{
		return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
	}

	/**
	* Calcula o ângulo entre mão, ombro e cotovelo.
	*/
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

	/**
		* Quando a tecla espaço é pressionada, este método é chamado.
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = !t;
		}
	}


	/**
	 * Captura os dados do movimento realizado pelo usuário e capturado pelo kinect.
	 */
	void FixedUpdate () {
		if (t)
		{
			current_time_movement += Time.fixedDeltaTime;
			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);

			grafico = new Vector2 (current_time_movement, angle (m_p, c_p, c_p, o_p));

			if (i > 750) {
				x_axis.localScale = new Vector3 (x_axis.localScale.x, x_axis.localScale.y + 0.02f, x_axis.localScale.z);
				x_axis.localPosition = new Vector3 (x_axis.localScale.y/2f, x_axis.localPosition.y, x_axis.localPosition.z);
				lineRenderer.positionCount++;
				resolution++;
			}

	        float divScale = (70 * resolution)/750f;
			float step = 2f / divScale;
			Vector3 scale = Vector3.one * step;
			Vector3 position = Vector3.zero;
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
	* Carrega materials e prefabs para plotagem do gráfico.
	*/
	void Awake()
	{
		points2 = new List<Vector3>();
		t = new bool();
		t = false;
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = 750;

		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
		lineRenderer.colorGradient = gradient;
	}
}
