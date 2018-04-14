using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* Pega pontos do movimento para o gráfico estático.
 */
public class GetMovementPoints : MonoBehaviour
{
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

	public Transform mao, cotovelo, ombro;
	Vector2 m_p, c_p, o_p, grafico;
	float current_time_movement = 0;
	bool t = false;

	/**
		* Quando a tecla espaço é pressionada, este método é chamado.
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = true;
		}
	}


	/**
	 * Captura os dados do movimento realizado pelo usuário e capturado pelo kinect.
	 */
	void FixedUpdate ()
	{
		if (t)
		{
			current_time_movement += Time.fixedDeltaTime;
			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);

			grafico = new Vector2 (current_time_movement, angle (m_p, c_p, c_p, o_p));

			StringBuilder sb = new StringBuilder();
			sb.Append(grafico.x).Append(" ").Append(grafico.y).Append("\n");
			System.IO.File.AppendAllText("Assets/points", sb.ToString());
		}
	}
}
