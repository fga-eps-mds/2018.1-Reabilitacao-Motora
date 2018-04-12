using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class possivel_solucao_para_armazenar_pontos_do_movimento : MonoBehaviour
{
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

	public Transform mao, cotovelo, ombro; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
//	List<Vector2> tempo_anguloDeJunta;
	Vector2 m_p, c_p, o_p, grafico;
	float current_time_movement = 0;
	bool t = false;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Start () {
//		tempo_anguloDeJunta = new List<Vector2> ();
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = true;
		}
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void FixedUpdate () {
		if (t) {
			current_time_movement += Time.fixedDeltaTime;
			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);
			//print (string.Format("LOCAL = mao X = \"{0}\" mao Y = \"{1}\"  ------ WORLD mao X = \"{2}\"  mao Y = \"{3}\"", mao.localPosition.x, mao.localPosition.y, mao.position.x, mao.position.y));
			//print (string.Format("LOCAL = cotovelo X = \"{0}\" cotovelo Y = \"{1}\"  ------ WORLD cotovelo X = \"{2}\"  cotovelo Y = \"{3}\"", cotovelo.localPosition.x, cotovelo.localPosition.y, cotovelo.position.x, cotovelo.position.y));
			//print (string.Format("LOCAL = ombro X = \"{0}\" ombro Y = \"{1}\"  ------ WORLD ombro X = \"{2}\"  ombro Y = \"{3}\"", ombro.localPosition.x, ombro.localPosition.y, ombro.position.x, ombro.position.y));


			grafico = new Vector2 (current_time_movement, angle (m_p, c_p, c_p, o_p));

			StringBuilder sb = new StringBuilder();
			sb.Append(grafico.x).Append(" ").Append(grafico.y).Append("\n");
			System.IO.File.AppendAllText("Assets/movementpoints.txt", sb.ToString());
		}
//tempo_anguloDeJunta.Add (grafico);
	}
}
